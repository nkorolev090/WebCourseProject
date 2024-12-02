using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BLL.Services
{
    public class DeviceTokenService : IDeviceTokenService
    {
        private readonly IDbRepository _db;
        private readonly UserManager<User> _userManager;
        public DeviceTokenService(IDbRepository dbRepository, UserManager<User> userManager)
        {
            _db = dbRepository;
            _userManager = userManager;
        }

        public async Task<DeviceTokenDTO?> CreateDeviceTokenAsync(ClaimsPrincipal currUser, string deviceToken)
        {
            var user = await _userManager.GetUserAsync(currUser);

            if (user == null)
            {
                return null;
            }

            var token = new DeviceToken
            {
                Token = deviceToken,
                UserId = user.Id,
                User = user
            };

            var tokenDto = await _db.DeviceTokens.CreateAsync(token);
            return new DeviceTokenDTO(tokenDto);
        }

        public async Task<IEnumerable<DeviceTokenDTO>?> GetUsersDeviceTokensAsync(ClaimsPrincipal currUser)
        {
            var user = await _userManager.GetUserAsync(currUser);

            if (user == null)
            {
                return null;
            }

            var tokens = await _db.DeviceTokens.GetListAsync();
            return tokens.Where(t => t.UserId == user.Id).Select(t=> new DeviceTokenDTO(t));
        }
    }
}
