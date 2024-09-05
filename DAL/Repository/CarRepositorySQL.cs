using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class CarRepositorySQL : IRepository<Car>
    {
        ModelAutoService db;
        public CarRepositorySQL(ModelAutoService db) { this.db = db; }

        public async Task<Car> CreateAsync(Car item)
        {
            db.Cars.Add(item);
            await db.SaveChangesAsync();
            return await db.Cars.LastAsync();
        }


        public async void DeleteAsync(int id)
        {
            Car? car = await db.Cars.FindAsync(id);
            if (car != null)
                db.Cars.Remove(car);
        }


        public async Task<Car?> GetItemAsync(int id)
        {
            return await db.Cars.FindAsync(id);
        }

        public async Task<List<Car>> GetListAsync()
        {
            return await db.Cars.ToListAsync();
        }

        public void Update(Car item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
