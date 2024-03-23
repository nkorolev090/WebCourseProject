using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class User : IdentityUser
    {
        public int? ClientId { get; set; }

        public int? MechanicId { get; set; }

        public virtual Client? Client { get; set; }

        public virtual Mechanic? Mechanic { get; set; }
    }
}
