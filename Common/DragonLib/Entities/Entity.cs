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
        protected Bounds Bounds;

        public Entity()
        {
            BoardPosition = new Position(0, 0);
        }

        public Entity(int positionX, int positionY) : this(positionX, positionY, 0) { }

        public Entity(int positionX, int positionY, int layer)
        {
            BoardPosition = new Position(positionX, positionY, layer);
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

        /// <summary>
        /// Return the position of the entity on the board.
        /// </summary>
        /// <returns></returns>
        public Position GetPosition()
        {
            return BoardPosition;
        }
    }
}
