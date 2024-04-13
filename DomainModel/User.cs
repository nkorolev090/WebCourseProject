using Microsoft.AspNetCore.Identity;

namespace DomainModel
{
    public class User : IdentityUser
    {
        public string? Name { get; set; } = null!;

        public string? Surname { get; set; } = null!;

        public string? Midname { get; set; } = null!;

        public int? ClientId { get; set; }

        public int? MechanicId { get; set; }

        public virtual Client? Client { get; set; }

        public virtual Mechanic? Mechanic { get; set; }
    }
}
