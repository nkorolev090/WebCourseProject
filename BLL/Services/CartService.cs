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

        public async Task<bool> AddCartItem(ClaimsPrincipal claimsPrincipal, int slotId, int breakdownId)
        {
            var cart = await getUserCart(claimsPrincipal);
            if(cart == null) return false;

            var breakdown = await _db.Breakdowns.GetItemAsync(breakdownId);
            var slot = await _db.Slots.GetItemAsync(slotId);
            if (slot == null || breakdown == null) return false;

            slot.Breakdown = breakdown;
            slot.BreakdownId = breakdown.Id;
            _db.Slots.Update(slot);

            var cartItem = new CartItem { Slot = slot, SlotId = slot.Id, Cart = cart, CartId = cart.Id };
            var crcartItem = await _db.CartItems.CreateAsync(cartItem);
            await _db.SaveAsync();

            cart.CartItems.Add(crcartItem);
            _db.Carts.Update(cart);

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

        public async Task<CartDTO?> RemoveCartItem(ClaimsPrincipal claimsPrincipal, int breakdownId)
        {
            var cart = await getUserCart(claimsPrincipal);
            if (cart == null) return null;

            var itemsToRemove = new List<CartItem>();

            foreach (CartItem item in cart.CartItems)
            {
                if (item.Slot.BreakdownId == breakdownId)
                {
                    item.Slot.BreakdownId = null;
                    item.Slot.Breakdown = null;
                    
                    itemsToRemove.Add(item);
                    _db.CartItems.DeleteAsync(item.Id);
                }
            }

            foreach(var item in itemsToRemove)
            {
                cart.CartItems.Remove(item);
            }

            await _db.SaveAsync();

            return cart.ToCartDto();
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
