using DemoAPI.Models;
using DemoAPI.ScoreData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private IScoreData _scoreData;

        public ScoreController(IScoreData scoreData)
        {
            _scoreData = scoreData;
        }

        [HttpGet]
        [Route("api/[controller]/all")]
        public IActionResult GetScores()
        {
            return Ok(_scoreData.GetScores());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetScore(Guid id)
        {
            var score = _scoreData.GetScore(id);

            if (score != null)
            {
                return Ok(score);
            }

            return NotFound($"Score with Id: {id} was not found.");
        }

        [HttpPost]
        [Route("api/[controller]/add")]
        public IActionResult AddScore(Guid playerId, int scoreValue, DateTime startedPlaying, DateTime endedPlaying)
        {
            var newScore = _scoreData.AddScore(playerId, scoreValue, startedPlaying, endedPlaying);
            return Created(
                HttpContext.Request.Scheme
                + "://"
                + HttpContext.Request.Host
                + HttpContext.Request.Path
                + "/" + newScore.Id, newScore);
        }

        [HttpDelete]
        [Route("api/[controller]/delete/{id}")]
        public IActionResult DeleteScore(Guid id)
        {
            var score = _scoreData.GetScore(id);

            if (score != null)
            {
                _scoreData.DeleteScore(score);
                return Ok();
            }

            return NotFound($"Score with Id: {id} was not found.");
        }
    }
}
