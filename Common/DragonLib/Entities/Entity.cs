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
        protected Boundaries Bounds;

        public Entity()
        {
            BoardPosition = new Position(0, 0);
        }

        /// <summary>
        /// Move the entiry to a new coordonate.
        /// </summary>
        /// <param name="PositionX">New x position</param>
        /// <param name="PositionY">New y position</param>
        public void MoveTo(int positionX, int positionY)
        {
            BoardPosition.ChangePosition(positionX, positionY);
        }

        public Position GetPosition()
        {
            return BoardPosition;
        }
    }
}
