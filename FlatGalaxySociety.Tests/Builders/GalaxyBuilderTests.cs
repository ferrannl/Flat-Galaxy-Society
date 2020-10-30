using FlatGalaxySociety.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySociety.Tests.Builders
{
    [TestClass]
    public class GalaxyBuilderTests
    {
        private GalaxyBuilder galaxyBuilder;
        private Mock<MainViewModel> mockMainViewModel;
        private Mock<StarFactory> mockStarFactory;
        private Mock<Galaxy> mockGalaxy;

        [TestInitialize]
        public void TestInit()
        {
            mockMainViewModel = MockMainViewModel();
            mockStarFactory = MockStarFactory();
            mockGalaxy = MockGalaxy(mockMainViewModel);
            galaxyBuilder = new GalaxyBuilder(mockGalaxy.Object);
        }

        /// <summary>
        /// AddStar doesn't have any logic to test, it's a wrapper for StarFactory's CreateStar function.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Add_Star_GivesException()
        {
            galaxyBuilder.AddStar(null);
        }

        /// <summary>
        /// Very happy flow
        /// </summary>
        [TestMethod]
        public void Link_Stars_FillStarsArray()
        {
            galaxyBuilder.LinkStars("Pear", "Pipi");
            Planet planet = (Planet)mockGalaxy.Object.stars.Where(star => star.GetType().IsAssignableFrom(typeof(Planet))).Where(planet1 => ((Planet)planet1).name == "Pear").First();
            Assert.AreEqual(1, planet.neighbours.Count());
            Planet planet2 = (Planet)mockGalaxy.Object.stars.Where(star => star.GetType().IsAssignableFrom(typeof(Planet))).Where(planet1 => ((Planet)planet1).name == "Pipi").First();
            Assert.AreEqual(planet.neighbours[0], planet2);
            mockGalaxy.VerifyGet(x => x.stars, Times.AtLeastOnce());
        }

        /// <summary>
        /// Predictable not happy flow
        /// </summary>
        /// 
        [TestMethod]
        [ExpectedException(typeof(InvalidLinkAttemptException))]
        public void Link_Stars_InvalidLinkAttemtException()
        {
            galaxyBuilder.LinkStars("Pear", "PietjePuk");
            Planet planet = (Planet)mockGalaxy.Object.stars.Where(star => star.GetType().IsAssignableFrom(typeof(Planet))).Where(planet1 => ((Planet)planet1).name == "Pear").First();
            Assert.AreEqual(1, planet.neighbours.Count());
            Planet planet2 = (Planet)mockGalaxy.Object.stars.Where(star => star.GetType().IsAssignableFrom(typeof(Planet))).Where(planet1 => ((Planet)planet1).name == "PietjePuk").First();
            Assert.AreEqual(planet.neighbours[0], planet2);
        }

        private Mock<MainViewModel> MockMainViewModel()
        {
            Mock<MainViewModel> mock = new Mock<MainViewModel>();
            return mock;
        }
        private Mock<StarFactory> MockStarFactory()
        {
            Mock<StarFactory> mock = new Mock<StarFactory>();
            mock.Setup(starFactory => starFactory.CreateStar(It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(),
                It.IsAny<double>(), It.IsAny<double>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new Planet("P", 200, 300, 0.55, 0.74, 10.0, new Disappear(), "red"));
            return mock;
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

    }
}
