using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BreakdownRepositorySQL : IRepository<Breakdown>
    {
        ModelAutoService db;
        public BreakdownRepositorySQL(ModelAutoService db) { this.db = db; }
        public void Create(Breakdown item)
        {
           db.Breakdowns.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Breakdowns.Find(id);
            if(item != null)
            {
                db.Breakdowns.Remove(item);
            }
        }

        public Breakdown GetItem(int id)
        {
           return db.Breakdowns.Find(id);
        }

        public List<Breakdown> GetList()
        {
            return db.Breakdowns.ToList();
        }

        public void Update(Breakdown item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
