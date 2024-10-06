using DomainModel;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class CartItemRepositorySQL : IRepository<CartItem>
    {
        private readonly ModelAutoService _db;
        public CartItemRepositorySQL(ModelAutoService db) { _db = db; }

        public async Task<CartItem> CreateAsync(CartItem item)
        {
            _db.CartItems.Add(item);
            await _db.SaveChangesAsync();
            return await _db.CartItems.LastAsync();
        }

        public async void DeleteAsync(int id)
        {
            var item = await _db.CartItems.FindAsync(id);
            if (item != null)
            {
                _db.CartItems.Remove(item);
            }
        }

        public Task<CartItem?> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartItem>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(CartItem item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
