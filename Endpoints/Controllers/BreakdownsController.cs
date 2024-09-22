using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Endpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakdownsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IBreakdownService breakdownService;

        public BreakdownsController(ILogger<BreakdownsController> logger, IBreakdownService breakdownService)
        {
            _logger = logger;
            this.breakdownService = breakdownService;
        }

        // GET: api/<BreakdownsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreakdownDTO>>> Get()
        {
            try
            {
                return await breakdownService.GetAllBreakdownsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }

        }

        // GET: api/<BreakdownsController>
        [HttpGet("byQuery")]
        public async Task<ActionResult<IEnumerable<BreakdownDTO>>> GetByQuery(string query)
        {
            try
            {
                return await breakdownService.GetBreakdownsByQueryAsync(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }

        }
    }
}
