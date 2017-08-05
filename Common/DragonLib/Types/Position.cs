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

        public void ChangePosition (int PositionX, int PositionY)
        {
            this.PositionX = PositionX;
            this.PositionY = PositionY;
        }

        public void ChangePosition(int PositionX, int PositionY, int Layer)
        {
            ChangePosition(PositionX, PositionY);
            ChangeLayer(Layer);
        }

        public void ChangeLayer(int Layer)
        {
            this.Layer = Layer;
        }
    }
}
