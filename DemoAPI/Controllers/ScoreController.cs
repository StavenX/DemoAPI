using DemoAPI.Contracts;
using DemoAPI.ScoreData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [Route(ApiRoutes.Scores.GetAll)]
        public IActionResult GetScores()
        {
            return Ok(_scoreData.GetScores());
        }

        [HttpGet]
        [Route(ApiRoutes.Scores.GetForPlayer)]
        public IActionResult GetScoresForPlayer(Guid id)
        {
            return Ok(_scoreData.GetScoresForPlayer(id));
        }

        [HttpGet]
        [Route(ApiRoutes.Scores.Get)]
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
        [Route(ApiRoutes.Scores.Add)]
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
        [Route(ApiRoutes.Scores.Delete)]
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
