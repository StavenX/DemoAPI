using DemoAPI.PlayerData;
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
    public class SummaryController : ControllerBase
    {
        private IPlayerData _playerData;
        private IScoreData _scoreData;

        public SummaryController(IPlayerData playerData, IScoreData scoreData)
        {
            _playerData = playerData;
            _scoreData = scoreData;
        }

        [HttpGet]
        [Route("api/[controller]/weekly")]
        public IActionResult GetWeeklyScores()
        {
            return Ok(_scoreData.GetScores());
        }
    }
}
