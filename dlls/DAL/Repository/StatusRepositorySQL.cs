using DomainModel;
using Interfaces.Repository;
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
        public void Create(Status item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Status GetItem(int id)
        {
            return db.Status.Find(id);
        }

        public List<Status> GetList()
        {
            return db.Status.ToList();
        }

        public void Update(Status item)
        {
            throw new NotImplementedException();
        }
    }
}
