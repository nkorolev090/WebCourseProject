using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ICarService
    {
        Task<List<CarDTO>> GetAllCarDTOAsync();
        Task<List<CarDTO>> GetAllClientCarDTOAsync(ClaimsPrincipal currUser);
        void CreateCarDTOAsync(CarDTO p);
        void UpdateCarDTOAsync(CarDTO p);
        Task<CarDTO> GetCarDTOAsync(int id);
        void DeleteCarDTOAsync(int id);
    }
}
