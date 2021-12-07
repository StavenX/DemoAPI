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
    }
}
