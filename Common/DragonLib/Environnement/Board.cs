using System;
using System.Collections.Generic;
using System.Text;
using DragonLib.Types;
using DragonLib.Entities;
using Newtonsoft.Json;

namespace DragonLib.Environnement
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Board
    {
        [JsonProperty]
        protected Dictionary<int, Entity> Elements;
        [JsonProperty]
        protected Bounds Limits;

        public Board() { }

        /// <summary>
        /// Set the bounds of the board and each elements on it.
        /// </summary>
        /// <param name="limits">Bounds for the board</param>
        public void SetBounds(Bounds limits)
        {
            if (limits != null)
            {
                Limits = limits;
                foreach (var item in Elements)
                {
                    item.Value.SetBounds(Limits);
                }
            }
            else
            {
                throw new ArgumentNullException("limits");
            }
        }
    }
}
