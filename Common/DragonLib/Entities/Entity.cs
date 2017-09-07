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
        public Position BoardPosition { get; protected set; }
        [JsonProperty]
        public string Location { get; protected set; }
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
        /// Sets the bounds for the entity.
        /// Throws OutOfBoundsException if the position is not inside the bounds.
        /// </summary>
        /// <param name="limits">Object representing the bounds of the enitiy</param>
        public void SetBounds(Bounds limits)
        {
            if (limits.IsInsideBounds(BoardPosition))
            {
                Bounds = limits;
            }
            else
            {
                throw new OutOfBoundsException();
            }
        }

        /// <summary>
        /// Sets the location for an entity
        /// </summary>
        /// <param name="location">The location of the entity</param>
        public void SetLocation(string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentNullException("location");
            }
            else
            {
                Location = location;
            }
        }

        /// <summary>
        /// Use Newtonsoft.Json to serialize the object into a json string
        /// </summary>
        /// <returns>Serialized values of the object</returns>
        public string SerializeJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Compare 2 entities to determine if they are equal in value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Entity)))
            {
                Entity entity = (Entity)obj;
                return CompareValues(entity);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Compare entity values
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected bool CompareValues(Entity entity)
        {
            return BoardPosition.Equals(entity.BoardPosition) && Location.Equals(entity.Location) && Bounds.Equals(entity.Bounds);
        }
    }
}
