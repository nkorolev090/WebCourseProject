using Interfaces.DTO;
using System.Security.Claims;

namespace Interfaces.Services
{
    public interface IDeviceTokenService
    {
        Task<IEnumerable<DeviceTokenDTO>?> GetUsersDeviceTokensAsync(string userId);
        Task<DeviceTokenDTO?> CreateDeviceTokenAsync(ClaimsPrincipal currUser, string deviceToken);
        Task<bool> DeleteDeviceTokenAsync(ClaimsPrincipal currUser, string deviceToken);
    }
}
