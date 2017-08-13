using DragonLib.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonLib.Entities
{
    public class Player : Entity
    {
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
