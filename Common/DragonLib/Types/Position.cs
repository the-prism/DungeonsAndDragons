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

        /// <summary>
        /// Change the coordinates.
        /// </summary>
        /// <param name="PositionX">New x position</param>
        /// <param name="PositionY">New y position</param>
        public void ChangePosition (int PositionX, int PositionY)
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
    }
}
