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
        /// <param name="layer"></param>
        public void ChangeLayer(int layer)
        {
            this.Layer = layer;
        }

        /// <summary>
        /// Adds or substracts to the current position.
        /// </summary>
        /// <param name="amountX"></param>
        /// <param name="amountY"></param>
        public void Move(int amountX, int amountY)
        {
            PositionX += amountX;
            PositionY += amountY;
        }

        /// <summary>
        /// Move the X position by the specified amount.
        /// </summary>
        /// <param name="Amount"></param>
        public void MoveX(int amount)
        {
            Move(amount, 0);
        }

        /// <summary>
        /// Move the Y position by the specified amount.
        /// </summary>
        /// <param name="amount"></param>
        public void MoveY(int amount)
        {
            Move(0, amount);
        }

        public bool IsOutOfBounds(Boundaries bounds)
        {
            return !bounds.IsInsideBounds(this);
        }

        private bool IsOutOfBoundsX(Boundaries bounds)
        {
            return !bounds.IsInsideXBounds(this.PositionX);
        }

        private bool IsOutOfBoundsY(Boundaries bounds)
        {
            return !bounds.IsInsideYBounds(this.PositionY);
        }

        private bool IsOutOfBoundsLayer(Boundaries bounds)
        {
            return !bounds.IsInsideLayerBounds(this.Layer);
        }
    }
}
