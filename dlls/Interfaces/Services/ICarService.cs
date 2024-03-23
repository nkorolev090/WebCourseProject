using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ICarService
    {
        List<CarDTO> GetAllCarDTO();
        List<CarDTO> GetAllCarDTO(int owner_id);
        void CreateCarDTO(CarDTO p);
        void UpdateCarDTO(CarDTO p);
        CarDTO GetCarDTO(int id);
        void DeleteCarDTO(int id);
    }
}
