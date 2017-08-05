using DragonLib.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragonLib.Entities
{
    public class Player : Entity
    {
        protected string Owner;
        Player() : base() { }

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
