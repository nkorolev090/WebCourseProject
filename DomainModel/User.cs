using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Midname { get; set; } = null!;

        private Client? Client { get; set; }

        private Mechanic? Mechanic { get; set; }
    }
}
