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
    }
}
