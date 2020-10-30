using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlatGalaxySociety.Models;
using Moq;

namespace FlatGalaxySociety.Tests
{
    [TestClass]
    public class PlanetTests
    {
        private Planet planet;
        private Mock<Star> mockStar;

        [TestCleanup]
        public void TestCleanup()
        {
            planet = null;
            mockStar = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            planet = new Planet("P", 500, 400, 0.55, 0.74, 10.0, new Disappear(), "red");
            mockStar = MockStar();
        }

        [TestMethod]
        public void CheckCollisionWall_RadiusGreaterThanX_InvertVx()
        {
            planet.x = 4;
            planet.CheckCollisionWall();
            Assert.AreEqual(-0.55, planet.vx);
        }

        [TestMethod]
        public void CheckCollisionWall_RadiusGreaterThanY_InvertVx()
        {
            planet.y = 4;
            planet.CheckCollisionWall();
            Assert.AreEqual(-0.74, planet.vy);
        }

        [TestMethod]
        public void CheckCollisionWall_XGreaterThanRadius_InvertVx()
        {
            planet.x = 55;
            planet.CheckCollisionWall();
            Assert.AreNotEqual(-0.55, planet.vx);
        }

        [TestMethod]
        public void CheckCollisionWall_YGreaterThanRadius_InvertVx()
        {
            planet.y = 55;
            planet.CheckCollisionWall();
            Assert.AreNotEqual(-0.74, planet.vy);
        }

        [TestMethod]
        public void CheckCollisionWall_XPlusRadiusGreaterThanGalaxyWidth_InvertVx()
        {
            planet.radius = 66 + Galaxy.WIDTH;
            planet.CheckCollisionWall();
            Assert.AreEqual(-0.55, planet.vx);
        }

        [TestMethod]
        public void CheckCollisionWall_YPlusRadiusGreaterThanGalaxyHeight_InvertVy()
        {
            planet.radius = 66 + Galaxy.HEIGHT;
            planet.CheckCollisionWall();
            Assert.AreEqual(-0.74, planet.vy);
        }

        [TestMethod]
        public void OnCollision_SameCoördinatesAsOtherAsteroid_VerifyCollision()
        {
            planet.x = 150;
            planet.y = 150;
            Assert.IsTrue(planet.HasCollision(mockStar.Object));
        }

        [TestMethod]
        public void OnCollision_DifferentCoördinatesAsOtherAsteroid_VerifyCollision()
        {
            Assert.IsFalse(planet.HasCollision(mockStar.Object));
        }

        private Mock<Star> MockStar()
        {
            Mock<Star> mock = new Mock<Star>(88.0, 77.0, 0.35, 0.34, 4.0, new Disappear(), "orange");
            mock.SetupGet(star => star.x).Returns(150.0);
            mock.SetupGet(star => star.y).Returns(150.0);
            mock.SetupGet(star => star.vx).Returns(0.35);
            mock.SetupGet(star => star.vy).Returns(0.34);
            return mock;
        }
    }
}
