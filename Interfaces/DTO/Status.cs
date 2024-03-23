using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Interfaces.DTO
{
    public class StatusDTO
    {
        public int id { get; set; }

        
        public string name { get; set; }

        public StatusDTO(Status status)
        {
            this.id = status.Id;
            this.name = status.Name;
        }
    }
}
