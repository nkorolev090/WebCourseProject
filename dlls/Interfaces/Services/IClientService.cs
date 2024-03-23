using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IClientService
    {
        List<ClientDTO> GetAllClientDTO();
        bool CreateClientDTO(ClientDTO p);
        void UpdateClientDTO(ClientDTO p);
        void UpdateClientDiscount(int id, int count);
        ClientDTO GetClientDTO(int id);
        void DeleteClientDTO(int id);
        int GetClientDiscount(int id);
    }
}
