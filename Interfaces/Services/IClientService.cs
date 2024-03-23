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
       Task<List<ClientDTO>> GetAllClientDTOAsync();
        Task<ClientDTO> CreateClientDTOAsync(ClientDTO p);
        void UpdateClientDTOAsync(ClientDTO p);
        void UpdateClientDiscountAsync(int id, int count);
        Task<ClientDTO> GetClientDTOAsync(int id);
        void DeleteClientDTOAsync(int id);
        Task<int> GetClientDiscountAsync(int id);
    }
}
