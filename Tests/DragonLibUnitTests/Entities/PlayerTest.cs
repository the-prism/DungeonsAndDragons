using System;
using DragonLib.Entities;
using DragonLib.Types;
using Xunit;

namespace DragonLibUnitTests.Entities
{
    public class PlayerTest
    {
        [Fact]
        public void TestMovingX()
        {
            Player test = new Player();
            test.MoveTo(4, 67);
            Position result = test.GetPosition();
            Assert.Equal(4, result.PositionX);
        }

        [Fact]
        public void TestMovingY()
        {
            Player test = new Player();
            test.MoveTo(4, 67);
            Position result = test.GetPosition();
            Assert.Equal(67, result.PositionY);
        }
    }
}
