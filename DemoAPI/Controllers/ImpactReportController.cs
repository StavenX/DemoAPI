using DemoAPI.Contracts;
using DemoAPI.PlayerData;
using DemoAPI.ScoreData;
using DemoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{
    [ApiController]
    public class ImpactReportController : ControllerBase
    {
        private IImpactReportFactory _impactReportFactory;

        public ImpactReportController(IImpactReportFactory impactReportFactory)
        {
            _impactReportFactory = impactReportFactory;
        }

        [HttpGet]
        [Route(ApiRoutes.ImpactReports.GetImpacts)]
        public IActionResult GetImpactReports()
        {
            return Ok(_impactReportFactory.GetAllImpactReports());
        }
    }
}
