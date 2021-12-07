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
        [Route("api/[controller]/all")]
        public IActionResult GetPlayers()
        {
            return Ok(_playerData.GetPlayers());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetPlayer(Guid id)
        {
            var player = _playerData.GetPlayer(id);

            if (player != null) {
                return Ok(player);
            }

            return NotFound($"Player with Id: {id} was not found.");
        }

        [HttpPost]
        [Route("api/[controller]/add")]
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
        [Route("api/[controller]/delete/{id}")]
        public IActionResult DeleteEmployee(Guid id)
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
        [Route("api/[controller]/edit/{id}")]
        public IActionResult EditEmployee(Guid id, Player player)
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
