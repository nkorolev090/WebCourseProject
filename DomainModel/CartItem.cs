using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class CartItem
    {
        public int Id { get; set; }
        public int SlotId { get; set; }
        public virtual Slot Slot { get; set; } = null!;
        public int? CartId { get; set; }
        public virtual Cart? Cart { get; set; } = null;
    }
}
