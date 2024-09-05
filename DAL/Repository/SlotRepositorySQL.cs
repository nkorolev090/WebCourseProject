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
    public class SlotRepositorySQL : IRepository<Slot>
    {
        ModelAutoService db;
        public SlotRepositorySQL(ModelAutoService db) { this.db = db; }

        public async Task<Slot> CreateAsync(Slot item)
        {
            db.Slots.Add(item);
            await db.SaveChangesAsync();
            return await db.Slots.LastAsync();
        }

        public async void DeleteAsync(int id)
        {
            var item = await db.Slots.FindAsync(id);
            if (item != null)
            {
                db.Slots.Remove(item);
            }
        }

        public async Task<Slot?> GetItemAsync(int id)
        {
            return await db.Slots.FindAsync(id);
        }
        
        public async Task<List<Slot>> GetListAsync()
        {
           return await db.Slots.ToListAsync();
        }

        public void Update(Slot item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
