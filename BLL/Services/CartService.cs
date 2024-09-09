using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CartService : ICartService
    {
        private readonly IDbRepository _db;
        private readonly IUserService _userService;

        public CartService(IDbRepository db, IUserService userService)
        {
            _db = db;
            _userService = userService;
        }

        public async Task<bool> AddCartItem(ClaimsPrincipal claimsPrincipal, CartItemDTO cartItem)
        {
            var cart = await getUserCart(claimsPrincipal);
            if(cart == null) return false;

            var slot = await _db.Slots.GetItemAsync(cartItem.id);
            if (slot == null) return false;

            cart.CartItems.Add(cartItem.ToCartItemDto(slot));
            await _db.SaveAsync();

            return true;
        }

        public async Task<CartDTO?> GetUserCartDTO(ClaimsPrincipal claimsPrincipal)
        {
            var cartDto = await getUserCart(claimsPrincipal);
            return cartDto.ToCartDto();
        }

        private async Task<Cart?> getUserCart(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userService.IsAuthenticatedAsync(claimsPrincipal);

            if (user == null || user.Client?.cart_id == null) return null;

            return await _db.Carts.GetItemAsync((int)user.Client.cart_id);
        }

        public async Task<bool> RemoveCartItem(ClaimsPrincipal claimsPrincipal, CartItemDTO cartItem)
        {
            var cart = await getUserCart(claimsPrincipal);
            if (cart == null) return false;

            var slot = await _db.Slots.GetItemAsync(cartItem.id);
            if (slot == null) return false;

            foreach (CartItem item in cart.CartItems)
            {
                if (item.Id == cartItem.id)
                {
                    cart.CartItems.Remove(item);

                    await _db.SaveAsync();

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> SetPromocode(ClaimsPrincipal claimsPrincipal, string promocode)
        {
            var cart = await getUserCart(claimsPrincipal);
            if (cart == null) return false;

            var promocodes = await _db.Promocodes.GetListAsync();
            var promo = promocodes.First(promo => promo.Title == promocode);
            if (promo == null) return false;

            cart.PromocodeId = promo.Id;
            cart.Promocode = promo;

            await _db.SaveAsync();

            return true;
        }
    }
}
