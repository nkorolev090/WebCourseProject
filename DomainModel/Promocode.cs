using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Promocode
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public double DiscountValue { get; set; }
        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    }
}
