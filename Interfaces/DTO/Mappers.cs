using DomainModel;
using Interfaces.Models;
using Interfaces.Services;

namespace Interfaces.DTO
{
    public static class Mappers
    {
        #region CartMapper
        public static CartDTO? ToCartDto(this Cart? cart) 
        {
            if (cart == null) return null;

            var subtotal = cart.CartItems.sumSubTotal();
            var discountValue = cart.Client.Discount.Sale / 100.0 * subtotal;

            var cartDto = new CartDTO() 
            {
                id = cart.Id,
                subtotal = subtotal,
                discount_value = discountValue,
                total = subtotal - discountValue,
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
            foreach(CartItem cartItem in cartItems)
            {
                sum += cartItem.Slot.Breakdown!.Price;
            }
            return sum;
        }

        #endregion

        #region NotificationMapper

        public static NotificationRoot toNotificationRoot(this NotificationType notificationType, Registration registration)
        {
            var notificationRoot = new NotificationRoot();
            notificationRoot.message = new Message();
            notificationRoot.message.data = new Data();
            //notificationRoot.message.notification = new Notification();

            switch (notificationType)
            {
                case NotificationType.REG_STATUS_UPDATE:
                    {
                        notificationRoot.message.data.title = $"Статус записи №{registration.Id} изменился";
                        notificationRoot.message.data.body = registration.Status switch
                        {
                            2 => "Ваша заявка одобрена",
                            3 => "Ваша заявка отклонена",
                            4 => "Ремонт завершен, можете забирать автомобиль",
                            _ => throw new NotImplementedException(),
                        };
                    }
                    break;

                case NotificationType.REG_CLOSE:
                    {

                    }
                    break;
                default:
                    {

                    }
                    break;
            }
            
            return notificationRoot;
        }
    #endregion
}
}
