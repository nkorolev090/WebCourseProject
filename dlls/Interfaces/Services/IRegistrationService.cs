using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IRegistrationService
    {
        RegistrationDTO GetItem(int id);
        List<RegistrationDTO> GetClientRegistrations(int client_id);
        List<RegistrationDTO> GetMechanicRegistrations(int mechanic_id);
        List<StatusDTO> GetStatuses();
        StatusDTO GetStatus(int id);
        RegistrationDTO CreateRegistration(RegistrationDTO registration);
        void UpdateRegistration(RegistrationDTO registration);
        void DeleteRegistration(int registration_id);
    }
}
