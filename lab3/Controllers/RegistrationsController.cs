using Microsoft.AspNetCore.Mvc;
//using lab.Models;
using DAL;
using Interfaces.DTO;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Cors;
using Interfaces.Services;
using BLL.Services;
using DomainModel;
using lab.Util;
using Ninject;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lab2.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {

        private readonly ModelAutoService _modelAutoService;
        private readonly IRegistrationService registrationService;

        public RegistrationsController(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }
        // GET: api/<RegistrationsController>byClientId?client_id=1
        [HttpGet("byClientId")]
        public async Task<ActionResult<IEnumerable<RegistrationDTO>>> GetClientRegistrations(int client_id)
        {
            return await registrationService.GetClientRegistrationsAsync(client_id);
        }

        // GET api/<RegistrationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationDTO>> GetRegistration(int id)
        {
            //var reg = await _modelAutoService.Registrations.FindAsync(id);
            //if (reg == null)
            //{
            //    return NotFound();
            //}
            //return reg;
            var reg = await registrationService.GetItemAsync(id);
            if (reg == null)
            {
                return NotFound();
            }
            return reg;
        }

        // POST api/<RegistrationsController>
        [HttpPost]
        [ActionName(nameof(PostRegistration))]
        public async Task<ActionResult<RegistrationDTO>> PostRegistration(RegistrationDTO registration)
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
                List<RegistrationDTO> _regs = await registrationService.GetClientRegistrationsAsync(registration.client_id);
                if (!_regs.Any(r => r.id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<RegistrationsController>/5
        [HttpDelete("{id}")]
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
