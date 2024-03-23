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
    public class MechanicRepositorySQL : IRepository<Mechanic>
    {
        ModelAutoService db;
        public MechanicRepositorySQL(ModelAutoService db) { this.db = db; }

        public Task<Mechanic> CreateAsync(Mechanic item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Mechanic>? GetItemAsync(int id)
        {
            return await db.Mechanics.FindAsync(id);
        }


        public async Task<List<Mechanic>> GetListAsync()
        {
            return await db.Mechanics.ToListAsync();
        }

        public void Update(Mechanic item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
