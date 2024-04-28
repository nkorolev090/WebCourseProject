using DomainModel;
using Interfaces.DTO;
using Interfaces.Models;
using System.Security.Claims;

namespace Interfaces.Services
{
    public interface IRegistrationService
    {
        Task<RegistrationDTO> GetItemAsync(int id);
        Task<List<RegistrationDTO>> GetRegistrationsAsync(ClaimsPrincipal currUser);
        Task<List<StatusDTO>> GetStatusesAsync();
        Task<StatusDTO> GetStatusAsync(int id);
        Task<RegistrationDTO> CreateRegistrationAsync(RegistrationViewModel registration);
        Task<int> UpdateRegistrationAsync(RegistrationDTO registration);
        Task<bool> DeleteRegistrationAsync(int registration_id);
    }
}
