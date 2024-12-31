using Microsoft.AspNetCore.Mvc;
using DAL;
using Interfaces.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Interfaces.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Endpoints.Controllers
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
        [HttpGet("getRegistrations")]
        [Authorize(Roles = "client, mechanic")]
        public async Task<ActionResult<IEnumerable<RegistrationViewModel>?>> GetRegistrations()
        {
            try
            {
                var registrationDTOs = await registrationService.GetRegistrationsAsync(HttpContext.User);

                List<RegistrationViewModel> response = new List<RegistrationViewModel>();
                foreach (RegistrationDTO registration in registrationDTOs)
                {
                    var slots = await slotService.GetRegistrationSlotsAsync(registration.id);
                    response.Add(new() { Registration = registration, Slots = slots});
                }
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }
            
        }

        // GET api/<RegistrationsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "client, mechanic")]
        public async Task<ActionResult<RegistrationViewModel>> GetRegistration(int id)
        {
            try
            {
                var reg = await registrationService.GetItemAsync(id);
                var slots = await slotService.GetRegistrationSlotsAsync(id);
                if (reg == null && slots == null)
                {
                    return NotFound();
                }
                return new RegistrationViewModel { Registration = reg, Slots = slots };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }
        }

        // POST api/<RegistrationsController>
        [HttpPost(nameof(PostRegistration))]
        [Authorize(Roles = "client")]
        public async Task<ActionResult<RegistrationDTO>> PostRegistration(RegistrationViewModel registration)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                RegistrationDTO? reg = await registrationService.CreateRegistrationAsync(registration, HttpContext.User);
                if(reg == null)
                {
                    return BadRequest(ModelState);
                }

                return reg;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }
        }

        // POST api/<RegistrationsController>
        [HttpPost(nameof(CreateRegistration))]
        [Authorize(Roles = "client")]
        public async Task<ActionResult<RegistrationDTO>> CreateRegistration()
        {
            try
            {
                RegistrationDTO? reg = await registrationService.CreateRegistrationAsync(HttpContext.User);
                if (reg == null)
                {
                    return BadRequest(ModelState);
                }

                return reg;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }
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
                await registrationService.UpdateRegistrationAsync(registration, HttpContext.User);
            }
            catch (DbUpdateConcurrencyException)
            {

                return NotFound();
            }

            return NoContent();
        }

        // PUT api/<RegistrationsController>/5
        [HttpPut(nameof(CloseRegistration))]
        [Authorize(Roles = "client, mechanic")]
        public async Task<ActionResult<int>> CloseRegistration(int id)
        {

            try
            {
                return await registrationService.CloseRegistrationAsync(id, HttpContext.User);
            }
            catch (DbUpdateConcurrencyException)
            {

                return NotFound();
            }
        }

        // DELETE api/<RegistrationsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "client, mechanic")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            try
            {
                await registrationService.DeleteRegistrationAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {

                return NotFound();
            }

            return NoContent();
        }
    }
}
