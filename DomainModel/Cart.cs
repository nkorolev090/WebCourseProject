using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Cart
    {
        public int Id { get; set; }
        public int? PromocodeId { get; set; }
        public virtual Promocode? Promocode { get; set; } = null;
        public int ClientId { get; set; }
        public virtual Client Client { get; set; } = null!;
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
