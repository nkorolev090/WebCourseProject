using Interfaces.Repository;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepositorySQL : IRepository<User>
    {
        ModelAutoService db;
        public UserRepositorySQL(ModelAutoService db) { this.db = db; }

        public Task<User> CreateAsync(User item)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
