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

        [TestMethod]
        public void TestSerializationEntity()
        {
            Entity test = new Entity();
            string json = JsonConvert.SerializeObject(test);
            string expected = "{\"BoardPosition\":{\"PositionX\":0,\"PositionY\":0,\"Layer\":0},\"Bounds\":null,\"Location\":\"\"}";
            Assert.AreEqual(expected, json);
        }

        [TestMethod]
        public void TestSerializationPlayer()
        {
            Player test = new Player();
            string json = JsonConvert.SerializeObject(test);
            string expected = "{\"Owner\":null,\"BoardPosition\":{\"PositionX\":0,\"PositionY\":0,\"Layer\":0},\"Bounds\":null,\"Location\":\"\"}";
            Assert.AreEqual(expected, json);
        }

        [TestClass]
        public class TestDeserializePlayerIntoEntity
        {
            static Entity tester;
            static string player = "{\"Owner\":null,\"BoardPosition\":{\"PositionX\":2,\"PositionY\":1,\"Layer\":-1},\"Location\":\"toto\",\"Bounds\":null}";

            [ClassInitialize]
            public static void SetUp(TestContext context)
            {
                tester = JsonConvert.DeserializeObject<Entity>(player);
            }

            [TestMethod]
            public void TestLocation()
            {
                Assert.AreEqual("toto", tester.Location);
            }

            [TestMethod]
            public void TestPositionX()
            {
                Assert.AreEqual(2, tester.GetPosition().PositionX);
            }

            [TestMethod]
            public void TestPositionY()
            {
                Assert.AreEqual(1, tester.GetPosition().PositionY);
            }

            [TestMethod]
            public void TestLayer()
            {
                Assert.AreEqual(-1, tester.GetPosition().Layer);
            }
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
                Assert.AreEqual(5, tester.GetPosition().PositionX);
            }

            [TestMethod]
            public void TestPositionY()
            {
                Assert.AreEqual(-3, tester.GetPosition().PositionY);
            }

            [TestMethod]
            public void TestLayer()
            {
                Assert.AreEqual(2, tester.GetPosition().Layer);
            }

            [TestMethod]
            public void TestOwnerIsNull()
            {
                Assert.IsNull(tester.GetOwner());
            }
        }
    }
}
