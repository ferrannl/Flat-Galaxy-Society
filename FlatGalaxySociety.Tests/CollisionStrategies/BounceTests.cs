using FlatGalaxySociety.Factories;
using FlatGalaxySociety.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySociety.Tests.CollisionStrategies
{
    [TestClass]
    public class BounceTests
    {
        private Mock<Star> mockStar;
        private Mock<Galaxy> mockGalaxy;
        private Mock<MainViewModel> mockMainViewModel;
        private Mock<CollisionStrategyFactory> mockCollisionStrategyFactory;
        private Bounce bounce;

        [TestCleanup]
        public void TestCleanup()
        {
            mockCollisionStrategyFactory = null;
            mockMainViewModel = null;
            mockStar = null;
            mockGalaxy = null;
            bounce = null;
        }
        [TestInitialize]
        public void TestInit()
        {
            mockMainViewModel = MockMainViewModel();
            mockStar = MockStar();
            mockGalaxy = MockGalaxy(mockMainViewModel);
            bounce = new Bounce();
        }

        [TestMethod]
        public void OnCollision_WithOtherObject_InvertsSpeed()
        {
            bounce.OnCollision(mockGalaxy.Object, mockStar.Object);
            Assert.AreEqual(-0.35, mockStar.Object.vx);
            Assert.AreEqual(-0.34, mockStar.Object.vy);
        }

        /// <summary>
        /// Can not test a singleton.. impossible to mock, hence why it fails.
        /// </summary>
        [TestMethod]
        public void OnCollision_BouncedMoreThanFiveTimes_ChangeCollisionStrategy()
        {
            for (int i = 0; i < 5; i++)
            {
                bounce.OnCollision(mockGalaxy.Object, mockStar.Object);
                mockCollisionStrategyFactory.Verify(colStratFactory => colStratFactory.GetNextStrategy(It.IsAny<CollisionStrategy>()), Times.Never());
            }
            Assert.AreEqual(5, bounce.counter);
            bounce.OnCollision(mockGalaxy.Object, mockStar.Object);
            Assert.AreNotEqual(typeof(Bounce), mockStar.Object.collisionStrategy.GetType());
            mockCollisionStrategyFactory.Verify(colStratFactory => colStratFactory.GetNextStrategy(It.IsAny<CollisionStrategy>()), Times.AtLeastOnce());
        }

        private Mock<Galaxy> MockGalaxy(Mock<MainViewModel> mockMainViewModel)
        {
            Mock<Galaxy> mock = new Mock<Galaxy>(mockMainViewModel.Object);
            mock.SetupGet(galaxy => galaxy.stars).Returns(new List<Star>
            {
            new Planet("Pear", 220, 303, 0.95, 0.72, 2.0, new Disappear(), "red"),
            new Planet("Pipi", 110, 330, 0.65, 0.24, 4.0, new Disappear(), "red"),
            new Asteroid(330, 301, 0.15, 0.66, 1.0, new Disappear(), "orange"),
            new Asteroid(500, 301, 0.25, 0.64, 7.0, new Disappear(), "black"),
            new Planet("Appe", 220, 308, 0.32, 0.74, 10.0, new Disappear(), "red"),
            new Planet("Pepe", 200, 306, 0.55, 0.90, 7.0, new Disappear(), "red"),
            new Asteroid(204, 304, 0.11, 0.14, 10.0, new Disappear(), "black"),
            });
            return mock;
        }

        private Mock<Star> MockStar()
        {
            Mock<Star> mock = new Mock<Star>(88.0, 77.0, 0.35, 0.34, 4.0, new Bounce(), "orange");
            mock.SetupProperty(star => star.vx, 0.35);
            mock.SetupProperty(star => star.vy, 0.34);
            //mock.SetupProperty(star => star.collisionStrategy, new Bounce());
            return mock;
        }

        private Mock<MainViewModel> MockMainViewModel()
        {
            Mock<MainViewModel> mock = new Mock<MainViewModel>();
            return mock;
        }

    }
}
