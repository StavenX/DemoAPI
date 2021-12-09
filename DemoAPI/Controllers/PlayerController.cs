using DemoAPI.Contracts;
using DemoAPI.Models;
using DemoAPI.PlayerData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IPlayerData _playerData; 

        public PlayerController(IPlayerData playerData)
        {
            _playerData = playerData;
        }

        [HttpGet]
        [Route(ApiRoutes.Players.GetAll)]
        public IActionResult GetPlayers()
        {
            return Ok(_playerData.GetPlayers());
        }

        [HttpGet]
        [Route(ApiRoutes.Players.Get)]
        public IActionResult GetPlayer(Guid id)
        {
            var player = _playerData.GetPlayer(id);

            if (player != null) {
                return Ok(player);
            }

            return NotFound($"Player with Id: {id} was not found.");
        }

        [HttpPost]
        [Route(ApiRoutes.Players.Add)]
        public IActionResult AddPlayer(Player player)
        {
            _playerData.AddPlayer(player);
            return Created(
                HttpContext.Request.Scheme
                + "://" 
                + HttpContext.Request.Host 
                + HttpContext.Request.Path 
                + "/" + player.Id, player);
        }

        [HttpDelete]
        [Route(ApiRoutes.Players.Delete)]
        public IActionResult DeletePlayer(Guid id)
        {
            var player = _playerData.GetPlayer(id);

            if (player != null)
            {
                _playerData.DeletePlayer(player);
                return Ok();
            }

            return NotFound($"Player with Id: {id} was not found.");
        }

        [HttpPatch]
        [Route(ApiRoutes.Players.Edit)]
        public IActionResult EditPlayer(Guid id, Player player)
        {
            var existingPlayer = _playerData.GetPlayer(id);

            if (existingPlayer != null)
            {
                player.Id = existingPlayer.Id;
                _playerData.EditPlayer(player);
            }

            return Ok(player);
        }
    }
}
