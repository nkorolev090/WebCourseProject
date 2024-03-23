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
    public class StatusRepositorySQL : IRepository<Status>
    {
        ModelAutoService db;
        public StatusRepositorySQL(ModelAutoService db) { this.db = db; }

        public Task<Status> CreateAsync(Status item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Status>? GetItemAsync(int id)
        {
            return await db.Statuses.FindAsync(id);
        }

        public async Task<List<Status>> GetListAsync()
        {
            return await db.Statuses.ToListAsync();
        }

        public void Update(Status item)
        {
            throw new NotImplementedException();
        }
    }
}
