using DomainModel;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class DeviceTokenRepositorySQL : IRepository<DeviceToken>
    {
        ModelAutoService db;
        public DeviceTokenRepositorySQL(ModelAutoService db) { this.db = db; }
        public async Task<DeviceToken> CreateAsync(DeviceToken item)
        {
            await db.DeviceTokens.AddAsync(item);
            await db.SaveChangesAsync();
            return await db.DeviceTokens.OrderBy(i => i.Id).LastOrDefaultAsync();
        }

        public async void DeleteAsync(int id)
        {
            var token = await db.DeviceTokens.FindAsync(id);
            if(token != null)
            {
                db.DeviceTokens.Remove(token);
            }
        }

        public async Task<DeviceToken?> GetItemAsync(int id)
        {
            return await db.DeviceTokens.FindAsync(id);
        }

        public async Task<List<DeviceToken>> GetListAsync()
        {
            return await db.DeviceTokens.ToListAsync();
        }

        public void Update(DeviceToken item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
