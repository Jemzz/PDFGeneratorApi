using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PDF.Models;
using PDF.Services.Interfaces;

namespace PDF.PDFGeneration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class SystemsController : ControllerBase
    {
        protected static Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IValuationReportService _service;

        /// <summary>
        /// Controller for system
        /// </summary>
        public SystemsController(IValuationReportService service)
        {
            _service = service;
        }

        // Post api/v1/systems/heartbeat
        /// <summary>
        /// POST - Heartbeat.</summary>
        /// <response code="200">Ok request</response>
        /// <response code="400">Missing/invalid values</response>
        /// <response code="404">Not found values</response>
        /// <response code="500">Internal server error</response>
        [HttpPost("heartbeat")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> Heartbeat([FromQuery] ReportsParameters parameters)
        {
            Logger.Info($"Heartbeat - UTC{DateTime.UtcNow}");
            var data = await _service.GetSecurityTrades(1, new DateTime(2021, 1, 1), new DateTime(2021, 1, 1));
            return await Task.FromResult(Ok());
        }

        /// <summary>
        /// Check status/200 request
        /// </summary>
        /// <returns></returns>
        [HttpGet("status")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> Status()
        {
            return await Task.FromResult(Ok());
        }
    }
}
