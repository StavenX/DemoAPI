using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoAPI.Repositories
{
    public class SqlPlayerRepository : IPlayerRepository
    {
        private ApiContext _apiContext;

        public SqlPlayerRepository(ApiContext playerContext)
        {
            _apiContext = playerContext;
        }
        public Player AddPlayer(Player player)
        {
            player.Id = Guid.NewGuid();

            _apiContext.Players.Add(player);
            _apiContext.SaveChanges();

            return player;
        }

        public void DeletePlayer(Player player)
        {
            _apiContext.Players.Remove(player);
            _apiContext.SaveChanges();
        }

        public Player EditPlayer(Player player)
        {
            var existingPlayer = _apiContext.Players.Find(player.Id);

            if (existingPlayer != null)
            {
                existingPlayer.Name = player.Name;
                _apiContext.Players.Update(existingPlayer);
                _apiContext.SaveChanges();
            }

            return player;
        }

        public Player GetPlayer(Guid id)
        {
            var player = _apiContext.Players.Find(id);
            return player;
        }

        public List<Player> GetPlayers()
        {
            return _apiContext.Players.ToList();
        }
    }
}
