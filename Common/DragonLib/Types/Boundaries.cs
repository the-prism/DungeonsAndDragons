using System;
using System.Collections.Generic;
using System.Text;

namespace DragonLib.Types
{
    public class Boundaries
    {
        public int MinX { get; protected set; }
        public int MaxX { get; protected set; }
        public int MinY { get; protected set; }
        public int MaxY { get; protected set; }
        public int MinLayer { get; protected set; }
        public int MaxLayer { get; protected set; }


        /// <summary>
        /// Builds boudaries with the specified coordinates
        /// </summary>
        /// <param name="MinX"></param>
        /// <param name="MaxX"></param>
        /// <param name="MinY"></param>
        /// <param name="MaxY"></param>
        public Boundaries(int MinX, int MaxX, int MinY, int MaxY)
        {
            this.MinX = MinX;
            this.MaxX = MaxX;
            this.MinY = MinY;
            this.MaxY = MaxY;
        }

        /// <summary>
        /// Builds boudaries fron 0,0 to the specified values
        /// </summary>
        /// <param name="MaxX"></param>
        /// <param name="MaxY"></param>
        public Boundaries(int MaxX, int MaxY) : this(0, MaxX, 0, MaxY) { }

        /// <summary>
        /// Builds boudaries with the specified coordinates and layers
        /// </summary>
        /// <param name="MinX"></param>
        /// <param name="MaxX"></param>
        /// <param name="MinY"></param>
        /// <param name="MaxY"></param>
        /// <param name="MinLayer"></param>
        /// <param name="MaxLayer"></param>
        public Boundaries(int MinX, int MaxX, int MinY, int MaxY, int MinLayer, int MaxLayer) : this(MinX, MaxX, MinY, MaxY)
        {
            this.MinLayer = MinLayer;
            this.MaxLayer = MaxLayer;
        }

        /// <summary>
        /// Sets the layer boudaries
        /// </summary>
        /// <param name="Min"></param>
        /// <param name="Max"></param>
        public void SetLayers(int Min, int Max)
        {
            MinLayer = Min;
            MaxLayer = Max;
        }

        /// <summary>
        /// Sets the boudaries for the x coordinates
        /// </summary>
        /// <param name="Min"></param>
        /// <param name="Max"></param>
        public void SetXBoudaries(int Min, int Max)
        {
            MinX = Min;
            MaxX = Max;
        }

        /// <summary>
        /// Sets the boudaries for the y coordinates
        /// </summary>
        /// <param name="Min"></param>
        /// <param name="Max"></param>
        public void SetYBoudaries(int Min, int Max)
        {
            MinY = Min;
            MaxY = Max;
        }
    }
}
