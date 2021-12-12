using DemoAPI.Routes;
using DemoAPI.Models;
using DemoAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DemoAPI.Controllers
{
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IPlayerRepository _playerRepository; 

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        [Route(ApiRoutes.Players.GetAll)]
        public IActionResult GetPlayers()
        {
            return Ok(_playerRepository.GetPlayers());
        }

        [HttpGet]
        [Route(ApiRoutes.Players.Get)]
        public IActionResult GetPlayer(Guid id)
        {
            var player = _playerRepository.GetPlayer(id);

            if (player != null) {
                return Ok(player);
            }

            return NotFound($"Player with Id: {id} was not found.");
        }

        [HttpPost]
        [Route(ApiRoutes.Players.Add)]
        public IActionResult AddPlayer(string name)
        {
            var newPlayer = new Player()
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            _playerRepository.AddPlayer(newPlayer);
            return Created(
                HttpContext.Request.Scheme
                + "://" 
                + HttpContext.Request.Host 
                + HttpContext.Request.Path 
                + "/" + newPlayer.Id, newPlayer);
        }

        [HttpDelete]
        [Route(ApiRoutes.Players.Delete)]
        public IActionResult DeletePlayer(Guid id)
        {
            var player = _playerRepository.GetPlayer(id);

            if (player != null)
            {
                _playerRepository.DeletePlayer(player);
                return Ok();
            }

            return NotFound($"Player with Id: {id} was not found.");
        }

        [HttpPatch]
        [Route(ApiRoutes.Players.Edit)]
        public IActionResult EditPlayer(Guid id, Player player)
        {
            var existingPlayer = _playerRepository.GetPlayer(id);

            if (existingPlayer != null)
            {
                player.Id = existingPlayer.Id;
                _playerRepository.EditPlayer(player);
            }

            return Ok(player);
        }
    }
}
