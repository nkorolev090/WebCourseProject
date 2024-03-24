using Interfaces.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IUserService
    {
       Task<IdentityResult> RegisterUserAsync(string email, string password, bool isClient);

        Task<SignInResult> SignInUserAsync(string email, string password, bool isPersistent);
        Task<bool> LogOffAsync(ClaimsPrincipal currUser);
        Task<bool> IsAuthenticatedAsync(ClaimsPrincipal currUser);
    }
}
