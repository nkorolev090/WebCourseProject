using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Interfaces.DTO
{
    public class MechanicDTO
    {
        public int id { get; set; }

        public string full_name { get; set; }

        public MechanicDTO(Mechanic mechanic) 
        { 
            id = mechanic.Id;
            full_name = mechanic.FullName;
        }
    }
}
