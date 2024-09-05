using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public partial class LoyaltyEvent
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int DiscountPoints { get; set; }
        public string ImageURL { get; set; } = null!;
    }
}
