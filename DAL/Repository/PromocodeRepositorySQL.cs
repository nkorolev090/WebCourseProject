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
    public class PromocodeRepositorySQL : IRepository<Promocode>
    {
        private readonly ModelAutoService _db;
        public PromocodeRepositorySQL(ModelAutoService db) { _db = db; }
        public Task<Promocode> CreateAsync(Promocode item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Promocode?> GetItemAsync(int id)
        {
            return await _db.Promocode.FindAsync(id);
        }

        public Task<List<Promocode>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Promocode item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
