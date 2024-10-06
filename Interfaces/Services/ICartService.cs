using Interfaces.DTO;
using System.Security.Claims;

namespace Interfaces.Services
{
    public interface ICartService
    {
        Task<CartDTO?> GetUserCartDTO(ClaimsPrincipal claimsPrincipal);

        Task<bool> AddCartItem(ClaimsPrincipal claimsPrincipal, int slotId, int breakdownId);

        Task<CartDTO?> RemoveCartItem(ClaimsPrincipal claimsPrincipal, int breakdownId);

        Task<bool> SetPromocode(ClaimsPrincipal claimsPrincipal, string promocode);
    }
}
