using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotsController : ControllerBase
    {
        private readonly ISlotService slotService;

        public SlotsController(ISlotService slotService)
        {
            this.slotService = slotService;
        }
        // GET: api/Slots/byDateBreakdown?date=a&breakdown_id=b
        [HttpGet("byDateBreakdown")]
        [Authorize(Roles = "client")]
        public async Task<ActionResult<IEnumerable<SlotDTO>>> Get(string date, int breakdown_id)
        {
            DateTime dateTime = DateTime.Parse(date);
            return await slotService.GetSlotsByDate_BreakdownAsync(dateTime, breakdown_id);
        }

        // GET api/<SlotsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SlotsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SlotsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SlotsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
