using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SlotRepositorySQL : IRepository<Slot>
    {
        ModelAutoService db;
        public SlotRepositorySQL(ModelAutoService db) { this.db = db; }
        public void Create(Slot item)
        {
            db.Slots.Add(item);
        }

        public void Delete(int id)
        {
            var item = db.Slots.Find(id);
            if(item != null)
            {
                db.Slots.Remove(item);
            }
        }

        public Slot GetItem(int id)
        {
           return db.Slots.Find(id);
        }

        public List<Slot> GetList()
        {
            return db.Slots.ToList();
        }

        public void Update(Slot item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
