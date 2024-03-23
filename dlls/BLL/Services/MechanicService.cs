using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
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
        public MechanicDTO GetMechanic(int id)
        {
           return new MechanicDTO(db.Mechanics.GetItem(id));
        }
    }
}
