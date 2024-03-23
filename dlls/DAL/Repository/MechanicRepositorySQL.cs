using DomainModel;
using Interfaces.Repository;
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
        public void Create(Mechanic item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Mechanic GetItem(int id)
        {
            return db.Mechanics.Find(id);
        }

        public List<Mechanic> GetList()
        {
            return db.Mechanics.ToList();
        }

        public void Update(Mechanic item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
