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
            var userTokens = await GetUsersDeviceTokensAsync(user.Id);
            if (userTokens!.Any(token => token.token == deviceToken)) return null;

            var token = new DeviceToken
            {
                Token = deviceToken,
                UserId = user.Id,
                User = user
            };

            var tokenDto = await _db.DeviceTokens.CreateAsync(token);
            return new DeviceTokenDTO(tokenDto);
        }

        public async Task<bool> DeleteDeviceTokenAsync(ClaimsPrincipal currUser, string deviceToken)
        {
            var user = await _userManager.GetUserAsync(currUser);

            if (user == null)
            {
                return false;
            }

            var userTokens = await GetUsersDeviceTokensAsync(user.Id);
            var tokenForDelete = userTokens?.Where(token => token.token == deviceToken).FirstOrDefault();
            if (tokenForDelete == null) return false;

            _db.DeviceTokens.DeleteAsync(tokenForDelete.id);
            return true;
        }

        public async Task<IEnumerable<DeviceTokenDTO>?> GetUsersDeviceTokensAsync(string userId)
        {
            var tokens = await _db.DeviceTokens.GetListAsync();
            return tokens.Where(t => t.UserId == userId).Select(t=> new DeviceTokenDTO(t));
        }
    }
}
