using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using DAL;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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

        public async Task<int> SaveAsync()
        {
            return await db.SaveChangesAsync();
        }
    }
}
