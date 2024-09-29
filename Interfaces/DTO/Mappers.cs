using DomainModel;
using Interfaces.Services;

namespace Interfaces.DTO
{
    public static class Mappers
    {
        public static CartDTO? ToCartDto(this Cart? cart) 
        {
            if (cart == null) return null;

            var cartDto = new CartDTO() 
            {
                id = cart.Id,
                subtotal = cart.CartItems.sumSubTotal(),
                cart_items = cart.CartItems.Select(item => item.ToCartItemDto()).ToList(),
            };

            if(cart.PromocodeId != null)
            {
                cartDto.total = cartDto.subtotal * cart.Promocode!.DiscountValue;
            }

            return cartDto;
        }

        public static CartItemDTO ToCartItemDto(this CartItem cartItem)
        {
            var itemDto = new CartItemDTO()
            {
                id = cartItem.Id,
                slot = new SlotDTO(cartItem.Slot),
            };

            return itemDto;
        }

        public static CartItem ToCartItem(this CartItemDTO cartItem, Slot slot)
        {
            var itemDto = new CartItem()
            {
                Id = cartItem.id,
                SlotId = slot.Id,
                Slot = slot,
            };

            return itemDto;
        }

        private static double sumSubTotal( this ICollection<CartItem> cartItems)
        {
            var sum = 0.0;
            cartItems.Select(item => sum += item.Slot.Breakdown!.Price);
            return sum;
        }
    }
}
