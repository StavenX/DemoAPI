using DemoAPI.Routes;
using DemoAPI.Factories;
using Microsoft.AspNetCore.Mvc;

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
