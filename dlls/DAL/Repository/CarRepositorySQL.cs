using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Interfaces.Repository;

namespace DAL.Repository
{
    public class CarRepositorySQL : IRepository<Car>
    {
        ModelAutoService db;
        public CarRepositorySQL(ModelAutoService db) { this.db = db; }

        public void Create(Car item)
        {
            db.Cars.Add(item);
        }

        public void Delete(int id)
        {
            Car car = db.Cars.Find(id);
            if(car != null)
                db.Cars.Remove(car);
        }

        public Car GetItem(int id)
        {
            return db.Cars.Find(id);
        }

        public List<Car> GetList()
        {
            return db.Cars.ToList();
        }

        public void Update(Car item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
