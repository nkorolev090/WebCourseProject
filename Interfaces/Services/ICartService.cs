using Interfaces.DTO;
using System.Security.Claims;

namespace Interfaces.Services
{
    public interface ICartService
    {
        Task<CartDTO?> GetUserCartDTO(ClaimsPrincipal claimsPrincipal);

        Task<bool> AddCartItem(ClaimsPrincipal claimsPrincipal, SlotDTO slotDto);

        Task<bool> RemoveCartItem(ClaimsPrincipal claimsPrincipal, CartItemDTO cartItem);

        Task<bool> SetPromocode(ClaimsPrincipal claimsPrincipal, string promocode);
    }
}
