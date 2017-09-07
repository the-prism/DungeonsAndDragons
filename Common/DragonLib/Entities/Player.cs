using DragonLib.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DragonLib.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Player : Entity
    {
        [JsonProperty]
        protected string Owner;

        public Player() : base() { }
        public Player(int positionX, int positionY) : base(positionX, positionY) { }
        public Player(int positionX, int positionY, int layer) : base(positionX, positionY, layer) { }

        /// <summary>
        /// Get the player that owns this unit
        /// </summary>
        /// <returns></returns>
        public string GetOwner()
        {
            return Owner;
        }

        /// <summary>
        /// Sets who owns the player unit
        /// </summary>
        /// <param name="owner">Owner of the unit</param>
        public void SetOwner(string owner)
        {
            if (string.IsNullOrEmpty(owner))
            {
                throw new ArgumentNullException("owner");
            }
            else
            {
                Owner = owner;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Player)))
            {
                Player player = (Player)obj;
                return CompareValues(player) && Owner.Equals(player.Owner);
            }
            else
            {
                return false;
            }
        }
    }
}
