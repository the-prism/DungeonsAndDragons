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
        public Dictionary<int, Entity> Elements { get; protected set; }
        [JsonProperty]
        public Dictionary<int, Player> Players { get; protected set; }
        [JsonProperty]
        public Bounds Limits { get; protected set; }

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
                SetEntityBounds(Limits);
            }
            else
            {
                throw new ArgumentNullException("limits");
            }
        }

        /// <summary>
        /// Add an entity to the board
        /// </summary>
        /// <param name="entity"></param>
        public void AddEntity(Entity entity)
        {
            entity.SetBounds(Limits);
            Elements.Add(Elements.Count, entity);
        }

        /// <summary>
        /// Add a player to the board
        /// </summary>
        /// <param name="entity"></param>
        public void AddPlayer(Player player)
        {
            player.SetBounds(Limits);
            Players.Add(Elements.Count, player);
        }

        private void SetEntityBounds(Bounds bounds)
        {
            foreach (var item in Elements)
            {
                item.Value.SetBounds(Limits);
            }
        }

        private void SetPlayerBounds(Bounds bounds)
        {
            foreach (var item in Players)
            {
                item.Value.SetBounds(Limits);
            }
        }
    }
}
