using DemoAPI.Models;
using System;
using System.Collections.Generic;

namespace DemoAPI.PlayerData
{
    public interface IPlayerData
    {
        List<Player> GetPlayers();
        Player GetPlayer(Guid id);
        Player AddPlayer(Player player);
        void DeletePlayer(Player player);
        Player EditPlayer(Player player);
    }
}
