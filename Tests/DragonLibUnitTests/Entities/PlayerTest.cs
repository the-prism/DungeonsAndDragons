using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonLib.Entities;
using DragonLib.Types;

namespace DragonLibUnitTests.Entities
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestMovingX()
        {
            Player test = new Player();
            test.MoveTo(4, 67);
            Position result = test.GetPosition();
            Assert.AreEqual(4, result.PositionX);
        }

        [TestMethod]
        public void TestMovingY()
        {
            Player test = new Player();
            test.MoveTo(4, 67);
            Position result = test.GetPosition();
            Assert.AreEqual(67, result.PositionX);
        }
    }
}
