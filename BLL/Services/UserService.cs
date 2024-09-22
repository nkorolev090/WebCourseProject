using Interfaces.Repository;
using Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using DomainModel;
using System.Security.Claims;
using Interfaces.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Interfaces.Models;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IDbRepository _db;
        private readonly IClientService _clientService;
        private readonly IMechanicService _mechanicService;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(IDbRepository db, UserManager<User> userManager, IClientService clientService, IMechanicService mechanicService, IConfiguration configuration) 
        {
            _db = db; 
            _userManager = userManager;
            _clientService = clientService;
            _mechanicService = mechanicService;
            _configuration = configuration;
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
            UserDTO user = await toUserDto(usr);
            return user;
        }

        public async Task<AutorizationResponse> RegisterUserAsync(string? name, string? midname, string? surname, string? phoneNumber, string email, string password)
        {
            User user;

            Client client = new Client();
            client.DiscountId = 1;
            client.Discount = await _db.Discouts.GetItemAsync(1);
            client.DiscountPoints = 0;

            Client cl = await _db.Clients.CreateAsync(client);

            Cart cart = await _db.Carts.CreateAsync(new() { ClientId = cl.Id, Client = cl });
            cl.CartId = cart.Id;
            cl.Cart = cart;
            await _db.SaveAsync();

            user = new() {Name = name, Midname = midname, Surname = surname, PhoneNumber = phoneNumber, Email = email, UserName = email, ClientId = cl.Id };
            
            var resultCreateUser = await _userManager.CreateAsync(user, password);

            if (resultCreateUser.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "client");
                // Генерация токена
                var token = await GenerateJwtToken(user);

                return new AutorizationResponse
                {
                    Token = token,
                    User = await toUserDto(user)
                };

            }

            return new AutorizationResponse { ErrorMessage = "Неверный логин или пароль" };
        }

        public async Task<AutorizationResponse> SignInUserAsync(string email, string password, bool isPersistent)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var token = await GenerateJwtToken(user);
                return new AutorizationResponse {
                    Token = token,
                    User = await toUserDto(user)
                };
            }
            else
            {
                return new AutorizationResponse { ErrorMessage = "Неверный логин или пароль"};
            }
        }

        private Task<User> GetCurrentUserAsync(ClaimsPrincipal currUser) => _userManager.GetUserAsync(currUser);

        // Метод для генерации JWT токена
        private async Task<string> GenerateJwtToken(User user)
        {
            // Объединяем имя, отчество и фамилию пользователя
            var fullName = $"{user.Name} {user.Midname} {user.Surname}";
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id), // Используем user.Id как основной идентификатор
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, fullName),  // Добавляем имя пользователя в клеймы
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            }.Union(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpiryMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<UserDTO> toUserDto(User user)
        {
            return new UserDTO
            {
                id = user.Id,
                midname = user.Midname,
                name = user.Name,
                surname = user.Surname,
                isClient = user.ClientId == null ? false : true,
                Client = user.ClientId == null ? null : await _clientService.GetClientDTOAsync((int)(user.ClientId)),
                Mechanic = user.MechanicId == null ? null : await _mechanicService.GetMechanicAsync((int)(user.MechanicId)),
                userName = user.UserName,
                email = user.Email,
                phoneNumber = user.PhoneNumber,
            };
        }
    }
}
