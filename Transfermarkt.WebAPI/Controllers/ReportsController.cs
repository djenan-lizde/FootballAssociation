using Microsoft.AspNetCore.Mvc;
using Transfermarkt.WebAPI.Attributes;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportGenerator _reportGenerator;

        public ReportsController(IReportGenerator reportGenerator)
        {
            _reportGenerator = reportGenerator;
        }

        [HttpGet("transfers")]
        [ExcelTemplate("TransfersTemplate.xslt")]
        public IActionResult GetReport()
        {
            return Ok(_reportGenerator.GetTransfersReport());
        }
    }
}
