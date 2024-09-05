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
    public class DiscountRepositorySQL : IRepository<Discount>
    {
        ModelAutoService db;
        public DiscountRepositorySQL(ModelAutoService db) { this.db = db; }

        public Task<Discount> CreateAsync(Discount item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Discount?> GetItemAsync(int id)
        {
            return await db.Discounts.FindAsync(id);
        }

        public async Task<List<Discount>> GetListAsync()
        {
            return await db.Discounts.ToListAsync();
        }

        public void Update(Discount item)
        {
            throw new NotImplementedException();
        }
    }
}
