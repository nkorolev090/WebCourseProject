using Interfaces.DTO;
using System.Security.Claims;

namespace Interfaces.Services
{
    public interface IClientService
    {
        Task<ClientDTO?> SetDefaultStation(int stationId, ClaimsPrincipal currUser);

        Task<ClientDTO?> SetDefaultCar(int id, ClaimsPrincipal currUser);

        Task<List<ClientDTO>> GetAllClientDTOAsync();

        Task<ClientDTO> CreateClientDTOAsync(ClientDTO p);

        void UpdateClientDTOAsync(ClientDTO p);

        void UpdateClientDiscountAsync(int id, int count);

        Task<ClientDTO> GetClientDTOAsync(int id);

        void DeleteClientDTOAsync(int id);

        Task<int> GetClientDiscountAsync(int id);
    }
}
