using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonLib.Entities;
using DragonLib.Types;
using Newtonsoft.Json;

namespace DragonLibUnitTests.Entities
{
    [TestClass]
    public class EntityTest
    {
        [TestMethod]
        public void TestComplexSerialization()
        {
            Entity tester = new Entity(4, 3, 1);
            Bounds limits = new Bounds(0, 34, 2, 3, 0, 5);
            tester.SetBounds(limits);
            tester.SetLocation("Here");
            string json = tester.SerializeJson();
            string expected = "{\"BoardPosition\":{\"PositionX\":4,\"PositionY\":3,\"Layer\":1},\"Location\":\"Here\"}";
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
                Assert.AreEqual(2, tester.BoardPosition.PositionX);
            }

            [TestMethod]
            public void TestPositionY()
            {
                Assert.AreEqual(1, tester.BoardPosition.PositionY);
            }

            [TestMethod]
            public void TestLayer()
            {
                Assert.AreEqual(-1, tester.BoardPosition.Layer);
            }
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
            string json = test.SerializeJson();
            string expected = "{\"BoardPosition\":{\"PositionX\":0,\"PositionY\":0,\"Layer\":0},\"Location\":\"\"}";
            Assert.AreEqual(expected, json);
        }
    }
}
