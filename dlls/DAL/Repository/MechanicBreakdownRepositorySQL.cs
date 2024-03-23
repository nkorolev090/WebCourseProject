using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class MechanicBreakdownRepositorySQL : IRepository<Mechanic_Breakdown>
    {
        ModelAutoService db;
        public MechanicBreakdownRepositorySQL(ModelAutoService db) { this.db = db; }
        public void Create(Mechanic_Breakdown item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Mechanic_Breakdown GetItem(int id)
        {
           return db.Mechanic_Breakdown.Find(id);
        }

        public List<Mechanic_Breakdown> GetList()
        {
            return db.Mechanic_Breakdown.ToList();
        }

        public void Update(Mechanic_Breakdown item)
        {
            throw new NotImplementedException();
        }
    }
}
