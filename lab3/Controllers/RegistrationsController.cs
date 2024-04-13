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
       // GET: api/<RegistrationsController>
       [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationDTO>>> GetClientRegistrations()
        {
            return await registrationService.GetRegistrationsAsync(HttpContext.User);
        }

        // GET api/<RegistrationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationDTO>> GetRegistration(int id)
        {
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

                return NotFound();
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
