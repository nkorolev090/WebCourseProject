using Interfaces.Repository;
using Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using DomainModel;
using System.Security.Claims;
using Interfaces.DTO;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IDbRepository db;
        private readonly IClientService _clientService;
        private readonly IMechanicService _mechanicService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserService(IDbRepository db, UserManager<User> userManager, SignInManager<User> signInManager, IClientService clientService, IMechanicService mechanicService) 
        {
            this.db = db; 
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._clientService = clientService;
            this._mechanicService = mechanicService;
        }

        public async Task<string?> GetUserRole(string currUserEmail)
        {
            User user = await _userManager.FindByEmailAsync(currUserEmail);
            IList<string>? roles = await _userManager.GetRolesAsync(user);
            string? userRole = roles.FirstOrDefault();
            return userRole;
        }

        public async Task<UserDTO?> IsAuthenticatedAsync(ClaimsPrincipal currUser)
        {
            User usr = await GetCurrentUserAsync(currUser);
            if (usr == null)
            {
                return null;
            }
            UserDTO user = new UserDTO
            {
                id = usr.Id,
                isClient = usr.ClientId == null ? false : true,
                Client = usr.ClientId == null ? null : await _clientService.GetClientDTOAsync((int)(usr.ClientId)),
                Mechanic = usr.MechanicId == null ? null : await _mechanicService.GetMechanicAsync((int)(usr.MechanicId)),
                userName = usr.UserName,
                email = usr.Email,
                phoneNumber = usr.PhoneNumber,
            };
            return user;
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

        public async Task<IdentityResult> RegisterUserAsync(string? name, string? midname, string? surname, string? phoneNumber, string email, string password)
        {
            User user;

            Client client = new Client();
            client.DiscountId = 1;
            client.Discount = await db.Discouts.GetItemAsync(1);
            client.DiscountPoints = 0;

            Client cl = await db.Clients.CreateAsync(client);
            user = new() {Name = name, Midname = midname, Surname = surname, PhoneNumber = phoneNumber, Email = email, UserName = email, ClientId = cl.Id };
            
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "client");
                // Установка куки
                await _signInManager.SignInAsync(user, false);

            }

            return result;
        }

        public async Task<SignInResult> SignInUserAsync(string email, string password, bool isPersistent)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent, false);
            return result;
        }

        private Task<User> GetCurrentUserAsync(ClaimsPrincipal currUser) => _userManager.GetUserAsync(currUser);
    }
}
