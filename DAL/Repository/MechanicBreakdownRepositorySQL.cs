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
    public class MechanicBreakdownRepositorySQL : IRepository<MechanicBreakdown>
    {
        ModelAutoService db;
        public MechanicBreakdownRepositorySQL(ModelAutoService db) { this.db = db; }

        public Task<MechanicBreakdown> CreateAsync(MechanicBreakdown item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<MechanicBreakdown>? GetItemAsync(int id)
        {
            return await db.MechanicBreakdowns.FindAsync(id);
        }

        public async Task<List<MechanicBreakdown>> GetListAsync()
        {
            return await db.MechanicBreakdowns.ToListAsync();
        }

        public void Update(MechanicBreakdown item)
        {
            throw new NotImplementedException();
        }
    }
}
