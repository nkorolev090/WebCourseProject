using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MechanicService : IMechanicService
    {
        IDbRepository db;
        public MechanicService(IDbRepository dbRepository) { db = dbRepository; }
        public async Task<MechanicDTO> GetMechanicAsync(int id)
        {
            Mechanic mechanic = await db.Mechanics.GetItemAsync(id);
           return new MechanicDTO(mechanic);
        }
    }
}
