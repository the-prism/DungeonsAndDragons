﻿using System;
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
            string json = JsonConvert.SerializeObject(tester);
            string expected = "{\"BoardPosition\":{\"PositionX\":4,\"PositionY\":3,\"Layer\":1},\"Bounds\":{\"MinX\":0,\"MaxX\":34,\"MinY\":2,\"MaxY\":3,\"MinLayer\":0,\"MaxLayer\":5,\"IgnoreLayer\":false},\"Location\":\"Here\"}";
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
    }
}