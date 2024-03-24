using Interfaces.DTO;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Interfaces.Services
{
    public interface IUserService
    {
       Task<IdentityResult> RegisterUserAsync(string email, string password/*, bool isClient*/);

        Task<SignInResult> SignInUserAsync(string email, string password, bool isPersistent);
        Task<bool> LogOffAsync(ClaimsPrincipal currUser);
        Task<UserDTO?> IsAuthenticatedAsync(ClaimsPrincipal currUser);
    }
}
