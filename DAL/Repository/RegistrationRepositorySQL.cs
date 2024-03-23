using DomainModel;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RegistrationRepositorySQL : IRepository<Registration>
    {
        ModelAutoService db;
        public RegistrationRepositorySQL(ModelAutoService db) { this.db = db; }

        public async Task<Registration> CreateAsync(Registration item)
        {
            db.Registrations.Add(item);
            await db.SaveChangesAsync();
            return await db.Registrations.OrderBy(i => i.Id).LastOrDefaultAsync();
        }

        public async void DeleteAsync(int id)
        {
            var item = await db.Registrations.FindAsync(id);
            if (item != null)
            {
                db.Registrations.Remove(item);
            }
        }

        public async Task<Registration>? GetItemAsync(int id)
        {
            return await db.Registrations.FindAsync(id);
        }


        public async Task<List<Registration>> GetListAsync()
        {
            return await db.Registrations.ToListAsync();
        }

        public void Update(Registration item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
