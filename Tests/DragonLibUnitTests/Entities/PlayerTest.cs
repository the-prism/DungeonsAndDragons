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
            Assert.AreEqual(67, result.PositionY);
        }

        [TestMethod]
        public void TestPlayerEntity()
        {
            Entity item = new Player(4, 3);
            item.Move(-2, -1);
            Assert.AreEqual(2, item.GetPosition().PositionX);
            Assert.AreEqual(2, item.GetPosition().PositionY);
        }

        [TestMethod]
        public void TestTypePlayer()
        {
            Entity player = new Player();
            Assert.AreEqual(typeof(Player), player.GetType());
        }

        [TestMethod]
        public void TestTypeEntity()
        {
            Entity player = new Entity();
            Assert.AreNotEqual(typeof(Player), player.GetType());
        }
    }
}
