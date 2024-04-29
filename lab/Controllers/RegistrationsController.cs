using Microsoft.AspNetCore.Mvc;
using DAL;
using Interfaces.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Interfaces.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab2.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IRegistrationService registrationService;
        private readonly ISlotService slotService;

        public RegistrationsController(ILogger<RegistrationsController> logger, IRegistrationService registrationService, ISlotService slotService)
        {
            _logger = logger;
            this.registrationService = registrationService;
            this.slotService = slotService;
        }
        // GET: api/<RegistrationsController>
        [HttpGet]
        [Authorize(Roles = "client, mechanic")]
        public async Task<ActionResult<IEnumerable<RegistrationDTO>>> GetRegistrations()
        {
            return await registrationService.GetRegistrationsAsync(HttpContext.User);
        }

        // GET api/<RegistrationsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "client, mechanic")]
        public async Task<ActionResult<RegistrationViewModel>> GetRegistration(int id)
        {
            var reg = await registrationService.GetItemAsync(id);
            var slots = await slotService.GetRegistrationSlotsAsync(id);
            if (reg == null && slots == null)
            {
                return NotFound();
            }
            return new RegistrationViewModel { Registration = reg, Slots = slots };
        }

        // POST api/<RegistrationsController>
        [HttpPost]
        [ActionName(nameof(PostRegistration))]
        [Authorize(Roles = "client")]
        public async Task<ActionResult<RegistrationDTO>> PostRegistration(RegistrationViewModel registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            RegistrationDTO _reg = await registrationService.CreateRegistrationAsync(registration);

            return CreatedAtAction("GetRegistration", new { id = _reg.id }, _reg);
        }

        // PUT api/<RegistrationsController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "client, mechanic")]
        public async Task<IActionResult> PutRegistration(int id, RegistrationDTO registration)
        {
            if (id != registration.id)
            {
                return BadRequest();
            }

            try
            {
                await registrationService.UpdateRegistrationAsync(registration);
            }
            catch (DbUpdateConcurrencyException)
            {

                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<RegistrationsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "client, mechanic")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var res = await registrationService.DeleteRegistrationAsync(id);
            
            if (!res)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
