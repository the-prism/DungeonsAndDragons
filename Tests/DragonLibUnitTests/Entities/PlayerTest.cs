using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonLib.Entities;
using DragonLib.Types;
using Newtonsoft.Json;

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
            Position result = test.BoardPosition;
            Assert.AreEqual(4, result.PositionX);
        }

        [TestMethod]
        public void TestMovingY()
        {
            Player test = new Player();
            test.MoveTo(4, 67);
            Position result = test.BoardPosition;
            Assert.AreEqual(67, result.PositionY);
        }

        [TestMethod]
        public void TestPlayerEntity()
        {
            Entity item = new Player(4, 3);
            item.Move(-2, -1);
            Assert.AreEqual(2, item.BoardPosition.PositionX);
            Assert.AreEqual(2, item.BoardPosition.PositionY);
        }

        [TestMethod]
        public void TestTypePlayer()
        {
            Entity player = new Player();
            Assert.AreEqual(typeof(Player), player.GetType());
        }

        [TestMethod]
        public void TestSerializationPlayer()
        {
            Player test = new Player();
            string json = JsonConvert.SerializeObject(test);
            string expected = "{\"Owner\":null,\"BoardPosition\":{\"PositionX\":0,\"PositionY\":0,\"Layer\":0},\"Location\":\"\"}";
            Assert.AreEqual(expected, json);
        }

        [TestClass]
        public class TestDeserializeEntityIntoPlayer
        {
            static Player tester;
            static string player = "{\"BoardPosition\":{\"PositionX\":5,\"PositionY\":-3,\"Layer\":2},\"Bounds\":null,\"Location\":\"something\"}";

            [ClassInitialize]
            public static void SetUp(TestContext context)
            {
                tester = JsonConvert.DeserializeObject<Player>(player);
            }

            [TestMethod]
            public void TestLocation()
            {
                Assert.AreEqual("something", tester.Location);
            }

            [TestMethod]
            public void TestPositionX()
            {
                Assert.AreEqual(5, tester.BoardPosition.PositionX);
            }

            [TestMethod]
            public void TestPositionY()
            {
                Assert.AreEqual(-3, tester.BoardPosition.PositionY);
            }

            [TestMethod]
            public void TestLayer()
            {
                Assert.AreEqual(2, tester.BoardPosition.Layer);
            }

            [TestMethod]
            public void TestOwnerIsNull()
            {
                Assert.IsNull(tester.GetOwner());
            }
        }

        [TestMethod]
        public void TestComplexSerialization()
        {
            Player tester = new Player(24, 13, 31);
            Bounds limits = new Bounds(20, 34, 2, 33, 10, 54);
            tester.SetBounds(limits);
            tester.SetLocation("someWhere");
            tester.SetOwner("dude");
            string json = JsonConvert.SerializeObject(tester);
            string expected = "{\"Owner\":\"dude\",\"BoardPosition\":{\"PositionX\":24,\"PositionY\":13,\"Layer\":31},\"Location\":\"someWhere\"}";
            Assert.AreEqual(expected, json);
        }
    }
}
