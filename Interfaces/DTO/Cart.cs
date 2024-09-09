using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class CartDTO
    {
        public int id { get; set; }
        public double total { get; set; }
        public double subtotal { get; set; }
        public int? promocode_id { get; set; }
        public string promocode_title { get; set; } = string.Empty;
        public double discount_value { get; set; }
        public ICollection<CartItemDTO> cart_items { get; set; } = new List<CartItemDTO>();
    }
}
