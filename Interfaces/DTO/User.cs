using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class UserDTO
    {
        public int id { get; set; }

        public string? email { get; set; }

        public string? password { get; set; }

        public string? userName { get; set; }

        public string? phoneNumber { get; set; }
        public bool? isClient {  get; set; }

        public ClientDTO? Client { get; set; }
        public MechanicDTO? Mechanic { get; set; }
    }
}
