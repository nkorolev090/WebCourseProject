using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RegistrationRepositorySQL : IRepository<Registration>
    {
        ModelAutoService db;
        public RegistrationRepositorySQL(ModelAutoService db) { this.db = db; }
        public void Create(Registration item)
        {
            db.Registrations.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Registrations.Find(id);
            if (item != null)
            {
                db.Registrations.Remove(item);
            }
        }

        public Registration GetItem(int id)
        {
            return db.Registrations.Find(id);
        }

        public List<Registration> GetList()
        {
            return db.Registrations.ToList();
        }

        public void Update(Registration item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
