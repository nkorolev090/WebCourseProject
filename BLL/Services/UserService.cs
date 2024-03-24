using Interfaces.Repository;
using Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using DomainModel;
using System.Security.Claims;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IDbRepository db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserService(IDbRepository db, UserManager<User> userManager, SignInManager<User> signInManager) 
        {
            this.db = db; 
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public async Task<bool> IsAuthenticatedAsync(ClaimsPrincipal currUser)
        {
            User usr = await GetCurrentUserAsync(currUser);
            if (usr == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> LogOffAsync(ClaimsPrincipal currUser)
        {
            User usr = await GetCurrentUserAsync(currUser);
            if (usr == null)
            {
                return false;
            }
            // Удаление куки
            await _signInManager.SignOutAsync();
            return true;
        }

        public async Task<IdentityResult> RegisterUserAsync(string email, string password, bool isClient)
        {
            Client client = new Client();
            client.Name = email;
            client.DiscountId = 1;
            client.Discount = await db.Discouts.GetItemAsync(1);
            client.DiscountPoints = 0;

            Client cl = await db.Clients.CreateAsync(client);
            User user = new() { Email = email, UserName = email, ClientId = cl.Id };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Установка куки
                await _signInManager.SignInAsync(user, false);

            }

            return result;
        }

        public async Task<SignInResult> SignInUserAsync(string email, string password, bool isPersistent)
        {
            var result = await _signInManager.PasswordSignInAsync(email,password, isPersistent, false);
            return result;
        }

        private Task<User> GetCurrentUserAsync(ClaimsPrincipal currUser) => _userManager.GetUserAsync(currUser);
    }
}
