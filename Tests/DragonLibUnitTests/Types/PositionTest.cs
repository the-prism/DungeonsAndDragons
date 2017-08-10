using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DragonLib.Types;

namespace DragonLibUnitTests.Types
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void TestPositionConstructorX()
        {
            Position position = new Position(34, 0);
            Assert.AreEqual(34, position.PositionX);
        }

        [TestMethod]
        public void TestPositionConstructorY()
        {
            Position position = new Position(0, 23);
            Assert.AreEqual(23, position.PositionY);
        }

        [TestMethod]
        public void TestPositionChangeX()
        {
            Position position = new Position(0, 23);
            position.ChangePosition(10, 23);
            Assert.AreNotEqual(0, position.PositionX);
            Assert.AreEqual(10, position.PositionX);
        }

        [TestMethod]
        public void TestPositionChangeY()
        {
            Position position = new Position(0, 0);
            position.ChangePosition(0, 23);
            Assert.AreNotEqual(0, position.PositionY);
            Assert.AreEqual(23, position.PositionY);
        }

        [TestMethod]
        public void TestMovePositionX()
        {
            Position position = new Position(3, 5);
            position.MoveX(2);
            Assert.AreEqual(5, position.PositionX);
        }

        [TestMethod]
        public void TestMovePositionNegativeX()
        {
            Position position = new Position(3, 5);
            position.MoveX(-2);
            Assert.AreEqual(1, position.PositionX);
        }

        [TestMethod]
        public void TestMovePositionY()
        {
            Position position = new Position(3, 5);
            position.MoveY(2);
            Assert.AreEqual(7, position.PositionY);
        }

        [TestMethod]
        public void TestMovePositionNegativeY()
        {
            Position position = new Position(3, 5);
            position.MoveY(-2);
            Assert.AreEqual(3, position.PositionY);
        }

        [TestMethod]
        public void TestMovingGlobalPositiveXNoY()
        {
            Position position = new Position(0, 0);
            position.Move(5, 0);
            Assert.AreEqual(5, position.PositionX);
            Assert.AreEqual(0, position.PositionY);
        }

        [TestMethod]
        public void TestMovingGlobalNegativeXNoY()
        {
            Position position = new Position(0, 0);
            position.Move(-5, 0);
            Assert.AreEqual(-5, position.PositionX);
            Assert.AreEqual(0, position.PositionY);
        }

        [TestMethod]
        public void TestMovingGlobalPositiveXPositiveY()
        {
            Position position = new Position(0, 0);
            position.Move(5, 5);
            Assert.AreEqual(5, position.PositionX);
            Assert.AreEqual(5, position.PositionY);
        }

        [TestMethod]
        public void TestMovingGlobalNegativeXPositiveY()
        {
            Position position = new Position(0, 0);
            position.Move(-5, 5);
            Assert.AreEqual(-5, position.PositionX);
            Assert.AreEqual(5, position.PositionY);
        }

        [TestMethod]
        public void TestMovingGlobalPositiveXNegativeY()
        {
            Position position = new Position(0, 0);
            position.Move(5, -5);
            Assert.AreEqual(5, position.PositionX);
            Assert.AreEqual(-5, position.PositionY);
        }

        [TestMethod]
        public void TestMovingGlobalNegativeXNegativeY()
        {
            Position position = new Position(0, 0);
            position.Move(-5, -5);
            Assert.AreEqual(-5, position.PositionX);
            Assert.AreEqual(-5, position.PositionY);
        }

        [TestMethod]
        public void TestMovingGlobalNoXPositiveY()
        {
            Position position = new Position(0, 0);
            position.Move(0, 5);
            Assert.AreEqual(0, position.PositionX);
            Assert.AreEqual(5, position.PositionY);
        }

        [TestMethod]
        public void TestMovingGlobalNoXNegativeY()
        {
            Position position = new Position(0, 0);
            position.Move(0, -5);
            Assert.AreEqual(0, position.PositionX);
            Assert.AreEqual(-5, position.PositionY);
        }
    }
}
