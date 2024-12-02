using DomainModel;
using Interfaces.DTO;

namespace AutoserviceTest.ServicesTests
{
    public class MapperTest
    {
        [Fact]
        public void toCartDtoTest()
        {
            List<CartItem> cartItems = new List<CartItem>()
            {
                 new CartItem { Id = 1, SlotId = 1, Slot = new Slot{Id = 1, BreakdownId = 1, Breakdown = new Breakdown {Price = 100, Id = 1, ImageUrl = "", Title = "", Warranty = 0,  }, MechanicId = 0, Mechanic = new Mechanic(){FullName = "" } } },
                 new CartItem { Id = 1, SlotId = 1, Slot = new Slot{Id = 1, BreakdownId = 1, Breakdown = new Breakdown {Price = 200, Id = 1, ImageUrl = "", Title = "", Warranty = 0,  }, MechanicId = 0, Mechanic = new Mechanic(){FullName = "" } } },
                 new CartItem { Id = 1, SlotId = 1, Slot = new Slot{Id = 1, BreakdownId = 1, Breakdown = new Breakdown {Price = 300, Id = 1, ImageUrl = "", Title = "", Warranty = 0,  }, MechanicId = 0, Mechanic = new Mechanic(){FullName = "" } } },
                 new CartItem { Id = 1, SlotId = 1, Slot = new Slot{Id = 1, BreakdownId = 1, Breakdown = new Breakdown {Price = 400, Id = 1, ImageUrl = "", Title = "", Warranty = 0,  }, MechanicId = 0, Mechanic = new Mechanic(){FullName = "" } } },
                 new CartItem { Id = 1, SlotId = 1, Slot = new Slot{Id = 1, BreakdownId = 1, Breakdown = new Breakdown {Price = 500, Id = 1, ImageUrl = "", Title = "", Warranty = 0,  }, MechanicId = 0, Mechanic = new Mechanic(){FullName = "" } } },
                 new CartItem { Id = 1, SlotId = 1, Slot = new Slot{Id = 1, BreakdownId = 1, Breakdown = new Breakdown {Price = 600, Id = 1, ImageUrl = "", Title = "", Warranty = 0,  }, MechanicId = 0, Mechanic = new Mechanic(){FullName = "" } } },
                 new CartItem { Id = 1, SlotId = 1, Slot = new Slot{Id = 1, BreakdownId = 1, Breakdown = new Breakdown {Price = 700, Id = 1, ImageUrl = "", Title = "", Warranty = 0,  }, MechanicId = 0, Mechanic = new Mechanic(){FullName = "" } } },
            };
            Cart cart = new Cart()
            {
                CartItems = cartItems,
                Client = new Client { Id = 1, Discount = new Discount { Sale = 20 } }
            };
            var cartDto = cart.ToCartDto();
            Assert.Equal(cartDto?.total, 2240);
        }
    }
}