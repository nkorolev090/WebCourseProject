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
    public class CartRepositorySQL : IRepository<Cart>
    {
        private readonly ModelAutoService _db;
        public CartRepositorySQL(ModelAutoService db) { _db = db; }
        public async Task<Cart> CreateAsync(Cart item)
        {
            _db.Carts.Add(item);
            await _db.SaveChangesAsync();
            return await _db.Carts.OrderBy(c => c.Id).LastOrDefaultAsync();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart?> GetItemAsync(int id)
        {
            return await _db.Carts.FindAsync(id);
        }

        public Task<List<Cart>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Cart item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
