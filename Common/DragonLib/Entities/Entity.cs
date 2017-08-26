using System;
using System.Collections.Generic;
using System.Text;
using DragonLib.Types;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace DragonLib.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Entity
    {
        [JsonProperty]
        protected Position BoardPosition;
        [JsonProperty]
        public string Location { get; protected set; }
        [JsonProperty]
        protected Bounds Bounds;

        public Entity() : this(0, 0) { }
        public Entity(int positionX, int positionY) : this(positionX, positionY, 0) { }

        public Entity(int positionX, int positionY, int layer)
        {
            BoardPosition = new Position(positionX, positionY, layer);
            Location = "";
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
        /// Move the entity by the specified amount.
        /// </summary>
        /// <param name="amountX">Value to move X coordinate</param>
        /// <param name="amountY">Value to move Y coordinate</param>
        public void Move(int amountX, int amountY)
        {
            BoardPosition.Move(amountX, amountY);
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
