using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoAPI.PlayerData
{
    public class MockPlayerData : IPlayerData
    {
        private List<Player> players = new List<Player>()
        {
            new Player()
            {
                Id = Guid.NewGuid(),
                Name = "Player One"
            },
            new Player()
            {
                Id = Guid.NewGuid(),
                Name = "Player Two"
            }
        };

        public Player AddPlayer(Player player)
        {
            player.Id = Guid.NewGuid();
            players.Add(player);
            return player;
        }

        public void DeletePlayer(Player player)
        {
            players.Remove(player);
        }

        public Player EditPlayer(Player player)
        {
            var existingPlayer = GetPlayer(player.Id);
            existingPlayer.Name = player.Name;
            return existingPlayer;
        }

        public Player GetPlayer(Guid id)
        {
            return players.SingleOrDefault(x => x.Id == id);
        }

        public List<Player> GetPlayers()
        {
            return players;
        }
    }
}
