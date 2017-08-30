using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonLib.Environnement;
using DragonLib.Entities;
using DragonLib.Types;

namespace DragonLibUnitTests.Environnement
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void TestBasicInit()
        {
            Board plate = new Board(20, 20);
            Assert.IsNotNull(plate);
        }

        [TestClass]
        public class TestFullInit
        {
            protected static Board Game;
            protected static List<Player> Actors;
            protected static List<Entity> Entities;

            [ClassInitialize]
            public static void SetUp(TestContext context)
            {
                SetPlayerList();
                SetEntityList();
                Game = new Board(10, 20, Entities, Actors);
            }

            private static void SetEntityList()
            {
                Entity entity1 = new Entity(6, 10, 0);
                entity1.SetLocation("Game Board Layer 0");
                Entity entity2 = new Entity(10, 20, 2);
                entity2.SetLocation("Game Board Layer 2");
                Entity entity3 = new Entity(5, 10, 1);
                entity3.SetLocation("Game Board Layer 1");
                Entity entity4 = new Entity(4, 17, 1);
                entity4.SetLocation("Game Board Layer 1");
                Entities = new List<Entity>() { entity1, entity2, entity3, entity4 };
            }

            private static void SetPlayerList()
            {
                Player player1 = new Player(2, 4, 1);
                player1.SetLocation("Game Board Layer 1");
                Player player2 = new Player(3, 2, 0);
                player2.SetLocation("Game Board Layer 0");
                Actors = new List<Player>() { player1, player2 };
            }

            [TestMethod]
            public void TestSuccesFullInit()
            {
                Assert.IsNotNull(Game);
            }
        }
    }
}
