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

        public Position() : this(0, 0) { }

        public Position(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
        }

        public Position(int positionX, int positionY, int layer) : this(positionX, positionY)
        {
            this.Layer = layer;
        }

        /// <summary>
        /// Change the coordinates.
        /// </summary>
        /// <param name="positionX">New x position</param>
        /// <param name="positionY">New y position</param>
        public void ChangePosition(int positionX, int positionY)
        {
            this.PositionX = positionX;
            this.PositionY = positionY;
        }

        /// <summary>
        /// Change the coordinates and the layer.
        /// </summary>
        /// <param name="positionX">New x position</param>
        /// <param name="positionY">New y position</param>
        /// <param name="layer">New layer</param>
        public void ChangePosition(int positionX, int positionY, int layer)
        {
            ChangePosition(positionX, positionY);
            ChangeLayer(layer);
        }

        /// <summary>
        /// Change the layer.
        /// </summary>
        /// <param name="layer">New layer position</param>
        public void ChangeLayer(int layer)
        {
            this.Layer = layer;
        }

        /// <summary>
        /// Adds or substracts to the current position.
        /// </summary>
        /// <param name="amountX">Value to move X coordinate</param>
        /// <param name="amountY">Value to move Y coordinate</param>
        public void Move(int amountX, int amountY)
        {
            PositionX += amountX;
            PositionY += amountY;
        }

        /// <summary>
        /// Move the X position by the specified amount.
        /// </summary>
        /// <param name="amount">Value to move X coordinate</param>
        public void MoveX(int amount)
        {
            Move(amount, 0);
        }

        /// <summary>
        /// Move the Y position by the specified amount.
        /// </summary>
        /// <param name="amount">Value to move Y coordinate</param>
        public void MoveY(int amount)
        {
            Move(0, amount);
        }

        /// <summary>
        /// Verify if the position is inside the bounds.
        /// </summary>
        /// <param name="bounds">The bounds to be used for verification</param>
        /// <returns></returns>
        public bool IsOutOfBounds(Bounds bounds)
        {
            return !bounds.IsInsideBounds(this);
        }
        
        private bool IsOutOfBoundsX(Bounds bounds)
        {
            return !bounds.IsInsideXBounds(this.PositionX);
        }
        
        private bool IsOutOfBoundsY(Bounds bounds)
        {
            return !bounds.IsInsideYBounds(this.PositionY);
        }

        private bool IsOutOfBoundsLayer(Bounds bounds)
        {
            return !bounds.IsInsideLayerBounds(this.Layer);
        }
    }
}
