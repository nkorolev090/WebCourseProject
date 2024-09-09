using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class CartItemDTO
    {
        public int id {  get; set; }
        public SlotDTO slot { get; set; } = null!;
    }
}
