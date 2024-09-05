using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Endpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ISlotService slotService;

        public SlotsController(ILogger<SlotsController> logger, ISlotService slotService)
        {
            _logger = logger;
            this.slotService = slotService;
        }
        // GET: api/Slots/byDateBreakdown?date=a&breakdown_id=b
        [HttpGet("byDateBreakdown")]
        [Authorize(Roles = "client")]
        public async Task<ActionResult<IEnumerable<SlotDTO>>> Get(string date, int breakdown_id)
        {
            try
            {
                DateTime dateTime = DateTime.Parse(date);
                return await slotService.GetSlotsByDate_BreakdownAsync(dateTime, breakdown_id);
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
