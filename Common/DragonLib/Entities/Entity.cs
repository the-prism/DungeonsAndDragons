using System;
using System.Collections.Generic;
using System.Text;
using DragonLib.Types;

namespace DragonLib.Entities
{
    public class Entity
    {
        protected Position BoardPosition;
        protected string Location;

        public void MoveTo(int PositionX, int PositionY)
        {
            BoardPosition.ChangePosition(PositionX, PositionY);
        }

        public Position GetPosition()
        {
            return BoardPosition;
        }
    }
}
