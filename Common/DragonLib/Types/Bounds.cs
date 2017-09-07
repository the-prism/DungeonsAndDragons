using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DragonLib.Types
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Bounds
    {
        [JsonProperty]
        public int MinX { get; protected set; }
        [JsonProperty]
        public int MaxX { get; protected set; }
        [JsonProperty]
        public int MinY { get; protected set; }
        [JsonProperty]
        public int MaxY { get; protected set; }
        [JsonProperty]
        public int MinLayer { get; protected set; }
        [JsonProperty]
        public int MaxLayer { get; protected set; }
        [JsonProperty]
        public bool IgnoreLayer { get; protected set; }

        /// <summary>
        /// Builds boudaries with the specified coordinates
        /// </summary>
        /// <param name="minX">Minimum value for the X coordinates</param>
        /// <param name="maxX">Maximum value for the X coordinates</param>
        /// <param name="minY">Minimum value for the Y coordinates</param>
        /// <param name="maxY">Maximum value for the Y coordinates</param>
        public Bounds(int minX, int maxX, int minY, int maxY)
        {
            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;
        }

        /// <summary>
        /// Builds boudaries with the specified coordinates and layers
        /// </summary>
        /// <param name="minX">Minimum value for the X coordinates</param>
        /// <param name="maxX">Maximum value for the X coordinates</param>
        /// <param name="minY">Minimum value for the Y coordinates</param>
        /// <param name="maxY">Maximum value for the Y coordinates</param>
        /// <param name="minLayer">Minimum value for the layer position</param>
        /// <param name="maxLayer">Maximum value for the layer position</param>
        public Bounds(int minX, int maxX, int minY, int maxY, int minLayer, int maxLayer) : this(minX, maxX, minY, maxY)
        {
            this.MinLayer = minLayer;
            this.MaxLayer = maxLayer;
        }

        /// <summary>
        /// Sets the layer boudaries
        /// </summary>
        /// <param name="min">Minimum value for the layer position</param>
        /// <param name="max">Maximum value for the layer position</param>
        public void SetLayers(int min, int max)
        {
            MinLayer = min;
            MaxLayer = max;
        }

        /// <summary>
        /// Sets the boudaries for the x coordinates
        /// </summary>
        /// <param name="min">Minimum value for the X coordinates</param>
        /// <param name="max">Maximum value for the X coordinates</param>
        public void SetXBoudaries(int min, int max)
        {
            MinX = min;
            MaxX = max;
        }

        /// <summary>
        /// Sets the boudaries for the y coordinates
        /// </summary>
        /// <param name="min">Minimum value for the Y coordinates</param>
        /// <param name="max">Maximum value for the Y coordinates</param>
        public void SetYBoudaries(int min, int max)
        {
            MinY = min;
            MaxY = max;
        }

        /// <summary>
        /// Specify weather or not to conside the layer bounds
        /// </summary>
        /// <param name="value">Should the layer be ignored</param>
        public void SetIgnoreLayer(bool value)
        {
            IgnoreLayer = value;
        }

        /// <summary>
        /// Verify if the position is inside the bounds
        /// </summary>
        /// <param name="position">Position with coodinates to verify</param>
        /// <returns></returns>
        public bool IsInsideBounds(Position position)
        {
            if(position == null)
            {
                throw new ArgumentNullException("position");
            }
            if (IgnoreLayer)
            {
                return IsInsideXBounds(position.PositionX) && IsInsideYBounds(position.PositionY);
            }
            else
            {
                return IsInsideXBounds(position.PositionX) && IsInsideYBounds(position.PositionY) && IsInsideLayerBounds(position.Layer);
            }
        }

        /// <summary>
        /// Verify is the value is inside the x bounds
        /// </summary>
        /// <param name="position">Value to check if it's inside the X bounds</param>
        /// <returns></returns>
        public bool IsInsideXBounds(int position)
        {
            return position >= MinX && position <= MaxX;
        }

        /// <summary>
        /// Verify is the value is inside the y bounds
        /// </summary>
        /// <param name="position">Value to check if it's inside the Y bounds</param>
        /// <returns></returns>
        public bool IsInsideYBounds(int position)
        {
            return position >= MinY && position <= MaxY;
        }

        /// <summary>
        /// Verfiy is the value is between the layer bounds
        /// </summary>
        /// <param name="layer">Value to check if it's inside the layer bounds</param>
        /// <returns></returns>
        public bool IsInsideLayerBounds(int layer)
        {
            return layer >= MinLayer && layer <= MaxLayer;
        }

        /// <summary>
        /// Compare 2 sets of bounds to determine if the are the same
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Bounds)))
            {
                Bounds bounds = (Bounds)obj;
                return CompareBounds(ref bounds);
            }
            else
            {
                return false;
            }
        }

        private bool CompareBounds(ref Bounds value)
        {
            return MinX == value.MinX && MaxX == value.MaxX && MinY == value.MinY && MaxY == value.MaxY && MinLayer == value.MinLayer && MaxLayer == value.MaxLayer && IgnoreLayer == value.IgnoreLayer;
        }
    }
}
