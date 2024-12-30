using DomainModel;
using Interfaces.DTO;
using Interfaces.Models;
using System.Security.Claims;

namespace Interfaces.Services
{
    public interface IRegistrationService
    {
        Task<RegistrationDTO> GetItemAsync(int id);
        Task<List<RegistrationDTO>?> GetRegistrationsAsync(ClaimsPrincipal currUser);
        Task<List<StatusDTO>> GetStatusesAsync();
        Task<StatusDTO> GetStatusAsync(int id);
        Task<RegistrationDTO?> CreateRegistrationAsync(RegistrationViewModel registration, ClaimsPrincipal currUser);
        Task<RegistrationDTO?> CreateRegistrationAsync(int carId, ClaimsPrincipal currUser);
        Task<int> UpdateRegistrationAsync(RegistrationDTO registration, ClaimsPrincipal currUser);
        Task<bool> DeleteRegistrationAsync(int registration_id);
        Task<int> CloseRegistrationAsync(int registrationId, ClaimsPrincipal currUser);
    }
}
