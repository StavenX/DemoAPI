using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
