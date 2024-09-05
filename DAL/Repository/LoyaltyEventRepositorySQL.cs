using DomainModel;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class LoyaltyEventRepositorySQL : IRepository<LoyaltyEvent>
    {
        private readonly ModelAutoService db;

        public LoyaltyEventRepositorySQL(ModelAutoService db)
        {
            this.db = db;
        }
        public async Task<LoyaltyEvent> CreateAsync(LoyaltyEvent item)
        {
            db.LoyaltyEvents.Add(item);
            await db.SaveChangesAsync();
            return await db.LoyaltyEvents.OrderBy(c => c.Id).LastOrDefaultAsync();
        }

        public async void DeleteAsync(int id)
        {
            var loyaltyEvent = await db.LoyaltyEvents.FindAsync(id);
            if (loyaltyEvent != null)
            {
                db.LoyaltyEvents.Remove(loyaltyEvent);
            }
        }

        public async Task<LoyaltyEvent?> GetItemAsync(int id)
        {
            return await db.LoyaltyEvents.FindAsync(id);
        }

        public async Task<List<LoyaltyEvent>> GetListAsync()
        {
            return await db.LoyaltyEvents.ToListAsync();
        }

        public void Update(LoyaltyEvent item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
