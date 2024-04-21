using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakdownsController : ControllerBase
    {
        private readonly IBreakdownService breakdownService;

        public BreakdownsController(IBreakdownService breakdownService)
        {
            this.breakdownService = breakdownService;
        }

        // GET: api/<BreakdownsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreakdownDTO>>> Get()
        {
            return await breakdownService.GetAllBreakdownsAsync();
        }

        // GET api/<BreakdownsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
