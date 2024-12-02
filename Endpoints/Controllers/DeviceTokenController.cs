using BLL.Services;
using Interfaces.DTO;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Endpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceTokenController: Controller
    { 

        private readonly ILogger _logger;
        private readonly IDeviceTokenService _deviceTokenService;

        public DeviceTokenController(ILogger<AccountController> logger, IDeviceTokenService deviceTokenService)
        {
            _logger = logger;
            _deviceTokenService = deviceTokenService;
        }


        [HttpPost(nameof(SaveDeviceToken))]
        [Authorize(Roles = "client, mechanic")]
        public async Task<ActionResult<DeviceTokenDTO>> SaveDeviceToken(string deviceToken)
        {
            try
            {
                var token = await _deviceTokenService.CreateDeviceTokenAsync(HttpContext.User, deviceToken);
                if(token == null)
                {
                    return BadRequest();
                }
                return token;
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
