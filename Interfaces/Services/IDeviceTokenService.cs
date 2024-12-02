using Interfaces.DTO;
using System.Security.Claims;

namespace Interfaces.Services
{
    public interface IDeviceTokenService
    {
        Task<IEnumerable<DeviceTokenDTO>?> GetUsersDeviceTokensAsync(ClaimsPrincipal currUser);
        Task<DeviceTokenDTO?> CreateDeviceTokenAsync(ClaimsPrincipal currUser, string deviceToken);
    }
}
