using DemoAPI.Models;
using System;
using System.Collections.Generic;

namespace DemoAPI.Repositories
{
    public interface IPlayerRepository
    {
        List<Player> GetPlayers();
        Player GetPlayer(Guid id);
        Player AddPlayer(Player player);
        void DeletePlayer(Player player);
        Player EditPlayer(Player player);
    }
}
