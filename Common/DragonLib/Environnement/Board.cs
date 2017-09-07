using System;
using System.Collections.Generic;
using System.Text;
using DragonLib.Types;
using DragonLib.Entities;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Serialization;

namespace DragonLib.Environnement
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Board
    {
        [JsonProperty]
        public List<Entity> Elements { get; protected set; }
        [JsonProperty]
        public List<Player> Players { get; protected set; }
        [JsonProperty]
        public Bounds Limits { get; protected set; }

        public Board() : this(0, 0) { }

        public Board(int sizeX, int sizeY)
        {
            Elements = new List<Entity>();
            Players = new List<Player>();
            Limits = new Bounds(0, sizeX, 0, sizeY, 0, 2);
        }
        public Board(int sizeX, int sizeY, List<Entity> entities, List<Player> players) : this(sizeX, sizeY)
        {
            foreach (Entity entity in entities)
            {
                this.AddEntity(entity);
            }
            foreach (Player player in players)
            {
                this.AddPlayer(player);
            }
        }

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
                SetPlayerBounds(Limits);
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
            Elements.Add(entity);
        }

        /// <summary>
        /// Add a player to the board
        /// </summary>
        /// <param name="entity"></param>
        public void AddPlayer(Player player)
        {
            player.SetBounds(Limits);
            Players.Add(player);
        }

        private void SetEntityBounds(Bounds bounds)
        {
            foreach (var item in Elements)
            {
                item.SetBounds(Limits);
            }
        }

        private void SetPlayerBounds(Bounds bounds)
        {
            foreach (var item in Players)
            {
                item.SetBounds(Limits);
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
        /// Evaluate if the 2 boards contain the same values
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(typeof(Board)))
            {
                Board board = (Board)obj;
                bool objectsEquals = ElementsEquals(board.Elements);
                objectsEquals = objectsEquals && PlayerEquals(board.Players);
                return objectsEquals;
            }
            else
            {
                return false;
            }
        }

        private bool ElementsEquals(List<Entity> list)
        {
            if (list.Count == Elements.Count)
            {
                Entity[] objArray = list.ToArray();
                Entity[] localArray = this.Elements.ToArray();
                bool result = true;

                Parallel.For(0, localArray.Length,
                    index =>
                    {
                        if (!objArray[index].Equals(localArray[index]))
                        {
                            result = false;
                        }
                    });
                return result;
            }
            else
            {
                return false;
            }
        }

        private bool PlayerEquals(List<Player> list)
        {
            if (list.Count == Players.Count)
            {
                Player[] objArray = list.ToArray();
                Player[] localArray = this.Players.ToArray();
                bool result = true;

                Parallel.For(0, localArray.Length,
                    index =>
                    {
                        if (!objArray[index].Equals(localArray[index]))
                        {
                            result = false;
                        }
                    });
                return result;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// After the board is deserialized, bounds needs to be updated on all containing objects
        /// </summary>
        [OnDeserialized]
        protected void OnDeserialized(StreamingContext context)
        {
            this.SetBounds(this.Limits);
        }
    }
}
