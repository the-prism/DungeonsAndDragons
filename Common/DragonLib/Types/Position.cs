using System;
using System.Collections.Generic;
using System.Text;

namespace DragonLib.Types
{
    public class Position
    {
        public int PositionX { get; protected set; }
        public int PositionY { get; protected set; }
        public int Layer { get; protected set; }

        public Position(int PositionX, int PositionY)
        {
            this.PositionX = PositionX;
            this.PositionY = PositionY;
        }

        public Position(int PositionX, int PositionY, int Layer) : this(PositionX, PositionY)
        {
            this.Layer = Layer;
        }

        /// <summary>
        /// Change the coordinates.
        /// </summary>
        /// <param name="PositionX">New x position</param>
        /// <param name="PositionY">New y position</param>
        public void ChangePosition(int PositionX, int PositionY)
        {
            this.PositionX = PositionX;
            this.PositionY = PositionY;
        }

        /// <summary>
        /// Change the coordinates and the layer.
        /// </summary>
        /// <param name="PositionX">New x position</param>
        /// <param name="PositionY">New y position</param>
        /// <param name="Layer">New layer</param>
        public void ChangePosition(int PositionX, int PositionY, int Layer)
        {
            ChangePosition(PositionX, PositionY);
            ChangeLayer(Layer);
        }

        /// <summary>
        /// Change the layer.
        /// </summary>
        /// <param name="Layer"></param>
        public void ChangeLayer(int Layer)
        {
            this.Layer = Layer;
        }

        /// <summary>
        /// Adds or substracts to the current position.
        /// </summary>
        /// <param name="AmountX"></param>
        /// <param name="AmountY"></param>
        public void Move(int AmountX, int AmountY)
        {
            PositionX += AmountX;
            PositionY += AmountY;
        }

        /// <summary>
        /// Move the X position by the specified amount.
        /// </summary>
        /// <param name="Amount"></param>
        public void MoveX(int Amount)
        {
            Move(Amount, 0);
        }

        /// <summary>
        /// Move the Y position by the specified amount.
        /// </summary>
        /// <param name="Amount"></param>
        public void MoveY(int Amount)
        {
            Move(0, Amount);
        }

        public bool IsOutOfBounds(Boundaries Bounds)
        {

        }
    }
}
