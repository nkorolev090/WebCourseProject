using BLL.Services;
using Interfaces.DTO;
using Interfaces.Services;
using Endpoints.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Endpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoyaltyEventController : Controller
    {
        private readonly ILogger _logger;
        private readonly ILoyaltyEventService _loyaltyEventService;
        public LoyaltyEventController(ILogger<LoyaltyEventController> logger, ILoyaltyEventService loyaltyEventService)
        {
            _logger = logger;
            _loyaltyEventService = loyaltyEventService;
        }

        // GET: api/<BreakdownsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoyaltyEventDTO>>> Get()
        {
            try
            {
                return await _loyaltyEventService.GetAllLoyaltyEventsAsync();
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
