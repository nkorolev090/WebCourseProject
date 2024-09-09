using DomainModel;
using Interfaces.Repository;

namespace DAL.Repository
{
    public class DbRepositorySQL : IDbRepository
    {
        private readonly ModelAutoService db;
        private ClientRepositorySQL clientRepository;
        private CarRepositorySQL carRepository;
        private SlotRepositorySQL slotRepository;
        private RegistrationRepositorySQL registrationRepository;
        private BreakdownRepositorySQL breakdownRepository;
        private MechanicRepositorySQL mechanicRepository;
        private MechanicBreakdownRepositorySQL mechanicBreakdownRepository;
        private StatusRepositorySQL statusRepository;
        private DiscountRepositorySQL discountRepository;
        private LoyaltyEventRepositorySQL loyaltyEventRepository;
        private CartRepositorySQL cartRepository;
        private CartItemRepositorySQL cartItemRepository;
        private PromocodeRepositorySQL promocodeRepository;

        public DbRepositorySQL(ModelAutoService db) {
            this.db = db;
        }

        public IRepository<Client> Clients 
        {
            get
            {
                if (clientRepository == null)
                {
                    clientRepository = new ClientRepositorySQL(db);
                }
                return clientRepository;
            }
        }

        public IRepository<Car> Cars
        {
            get
            {
                if (carRepository == null)
                {
                    carRepository = new CarRepositorySQL(db);
                }
                return carRepository;
            }
        }

        public IRepository<Slot> Slots
        {
            get
            {
                if (slotRepository == null)
                {
                    slotRepository = new SlotRepositorySQL(db);
                }
                return slotRepository;
            }
        }

        public IRepository<Registration> Registrations
        {
            get
            {
                if (registrationRepository == null)
                {
                    registrationRepository = new RegistrationRepositorySQL(db);
                }
                return registrationRepository;
            }
        }

        public IRepository<Breakdown> Breakdowns
        {
            get
            {
                if (breakdownRepository == null)
                {
                    breakdownRepository = new BreakdownRepositorySQL(db);
                }
                return breakdownRepository;
            }
        }

        public IRepository<Mechanic> Mechanics
        {
            get
            {
                if (mechanicRepository == null)
                {
                    mechanicRepository = new MechanicRepositorySQL(db);
                }
                return mechanicRepository;
            }
        }

        public IRepository<MechanicBreakdown> Mechanic_Breakdowns
        {
            get
            {
                if (mechanicBreakdownRepository == null)
                {
                    mechanicBreakdownRepository = new MechanicBreakdownRepositorySQL(db);
                }
                return mechanicBreakdownRepository;
            }
        }

        public IRepository<Status> Statuses
        {
            get
            {
                if (statusRepository == null)
                {
                    statusRepository = new StatusRepositorySQL(db);
                }
                return statusRepository;
            }
        }

        public IRepository<Discount> Discouts
        {
            get
            {
                if (discountRepository == null)
                {
                    discountRepository = new DiscountRepositorySQL(db);
                }
                return discountRepository;
            }
        }

        public IRepository<LoyaltyEvent> LoyaltyEvents
        {
            get
            {
                if (loyaltyEventRepository == null)
                {
                    loyaltyEventRepository = new LoyaltyEventRepositorySQL(db);
                }
                return loyaltyEventRepository;
            }
        }
        public IRepository<Cart> Carts
        {
            get
            {
                if (cartRepository == null)
                {
                    cartRepository = new CartRepositorySQL(db);
                }
                return cartRepository;
            }
        }

        public IRepository<CartItem> CartItems
        {
            get
            {
                if (cartItemRepository == null)
                {
                    cartItemRepository = new CartItemRepositorySQL(db);
                }
                return cartItemRepository;
            }
        }

        public IRepository<Promocode> Promocodes
        {
            get
            {
                if (promocodeRepository == null)
                {
                    promocodeRepository = new PromocodeRepositorySQL(db);
                }
                return promocodeRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await db.SaveChangesAsync();
        }
    }
}
