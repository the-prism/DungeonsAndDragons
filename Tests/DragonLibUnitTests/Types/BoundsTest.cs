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

        }
    }
}
