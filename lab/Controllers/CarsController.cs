using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }
        // GET: api/<CarsController>
        [HttpGet]
        public async Task<IEnumerable<CarDTO>> Get()
        {
            return await carService.GetAllClientCarDTOAsync(HttpContext.User);
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
