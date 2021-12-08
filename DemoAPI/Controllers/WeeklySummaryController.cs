﻿using DemoAPI.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{
    [ApiController]
    public class WeeklySummaryController : ControllerBase
    {
        private IWeeklySummaryFactory _weeklySummaryFactory;

        public WeeklySummaryController(IWeeklySummaryFactory weeklySummaryFactory)
        {
            _weeklySummaryFactory = weeklySummaryFactory;
        }

        [HttpGet]
        [Route("api/[controller]/{weekNumber}")]
        public IActionResult GetWeeklySummaries(int weekNumber)
        {
            return Ok(_weeklySummaryFactory.GetWeeklySummaries(weekNumber));
        }

        // Return weekly summaries for current week?
        /*
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetWeeklySummariesTest()
        {
            return Ok(_weeklySummaryFactory.GetWeeklySummaries(1));
        }*/
    }
}
