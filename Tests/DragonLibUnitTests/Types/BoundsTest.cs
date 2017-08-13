using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonLib.Types;

namespace DragonLibUnitTests.Types
{
    [TestClass]
    public class BoundsTest
    {
        [TestMethod]
        public void TestBoundsFrom0()
        {
            Bounds limit = new Bounds(45, 25);
            Assert.AreEqual(0, limit.MinX);
            Assert.AreEqual(0, limit.MinY);
            Assert.AreEqual(45, limit.MaxX);
            Assert.AreEqual(25, limit.MaxY);
        }

        [TestMethod]
        public void TestBoundsFrom2()
        {
            Bounds limit = new Bounds(2, 6, 2, 3);
            Assert.AreEqual(2, limit.MinX);
            Assert.AreEqual(2, limit.MinY);
            Assert.AreEqual(6, limit.MaxX);
            Assert.AreEqual(3, limit.MaxY);
        }

        [TestMethod]
        public void TestExpandBounds()
        {
            Bounds limit = new Bounds(2, 6, 2, 3);
            Assert.AreEqual(2, limit.MinX);
            limit.SetXBoudaries(0, 6);
            Assert.AreEqual(0, limit.MinX);
        }

        [TestMethod]
        public void TestIsInsideBounds()
        {
            Bounds limit = new Bounds(-2, 2, -2, 2);
            Position position = new Position(0, 0);
            bool result = limit.IsInsideBounds(position);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestIsInsideBoundsX()
        {
            Bounds limit = new Bounds(-2, 2, -2, 2);
            bool result = limit.IsInsideXBounds(1);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestIsInsideBoundsY()
        {
            Bounds limit = new Bounds(-2, 2, -2, 2);
            bool result = limit.IsInsideXBounds(-2);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestIsOutsideBounds()
        {
            Bounds limit = new Bounds(-2, 2, -2, 2);
            Position position = new Position(0, 3);
            bool result = limit.IsInsideBounds(position);
            Assert.AreEqual(false, result);
        }
    }
}
