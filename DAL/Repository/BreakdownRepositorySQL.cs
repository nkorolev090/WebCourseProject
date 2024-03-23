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
    public class BreakdownRepositorySQL : IRepository<Breakdown>
    {
        ModelAutoService db;
        public BreakdownRepositorySQL(ModelAutoService db) { this.db = db; }
        public async Task<Breakdown> CreateAsync(Breakdown item)
        {
           //db.Breakdowns.Add(item);
           throw new NotImplementedException();
          
        }

        public async void DeleteAsync(int id)
        {
            var item = await db.Breakdowns.FindAsync(id);
            if(item != null)
            {
                db.Breakdowns.Remove(item);
            }
        }

        public async Task<Breakdown>? GetItemAsync(int id)
        {
           return await db.Breakdowns.FindAsync(id);
        }

        public async Task<List<Breakdown>> GetListAsync()
        {
            return  await db.Breakdowns.ToListAsync();
        }


        public void Update(Breakdown item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
