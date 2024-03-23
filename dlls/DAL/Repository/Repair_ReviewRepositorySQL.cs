using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repair_ReviewRepositorySQL : IRepository<Repair_Review>
    {
        ModelAutoService db;
        public Repair_ReviewRepositorySQL(ModelAutoService db) { this.db = db; }
        public void Create(Repair_Review item)
        {
            db.Repair_Review.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Repair_Review.Find(id);
            if(item  != null)
            {
                db.Repair_Review.Remove(item);
            }
        }

        public Repair_Review GetItem(int id)
        {
            return db.Repair_Review.Find(id);
        }

        public List<Repair_Review> GetList()
        {
            return db.Repair_Review.ToList();
        }

        public void Update(Repair_Review item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
