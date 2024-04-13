using DomainModel;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IRegistrationService
    {
        Task<RegistrationDTO> GetItemAsync(int id);
        Task<List<RegistrationDTO>> GetRegistrationsAsync(ClaimsPrincipal currUser);
        Task<List<StatusDTO>> GetStatusesAsync();
        Task<StatusDTO> GetStatusAsync(int id);
        Task<RegistrationDTO> CreateRegistrationAsync(RegistrationDTO registration);
        Task<int> UpdateRegistrationAsync(RegistrationDTO registration);
        Task<bool> DeleteRegistrationAsync(int registration_id);
    }
}
