using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Endpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICarService carService;

        public CarsController(ILogger<CarsController> logger, ICarService carService)
        {
            _logger = logger;
            this.carService = carService;
        }

        // GET: api/<CarsController>
        [HttpGet(nameof(GetCars))]
        [Authorize(Roles = "client")]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetCars()
        {
            try
            {
                return await carService.GetAllClientCarDTOAsync(HttpContext.User);
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
