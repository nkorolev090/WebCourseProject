using DomainModel;
using Interfaces.DTO;
using Interfaces.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Interfaces.Services
{
    public interface IUserService
    {
        Task<AutorizationResponse> RegisterUserAsync(string? name, string? midname, string? surname, string? phoneNumber, string email, string password);

        Task<AutorizationResponse> SignInUserAsync(string email, string password, bool isPersistent);

        Task<UserDTO?> IsAuthenticatedAsync(ClaimsPrincipal currUser);

        Task<string?> GetUserRole(string currUserEmail);

    }
}
