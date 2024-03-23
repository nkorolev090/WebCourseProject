using DomainModel;
using Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DiscountRepositorySQL : IRepository<Discount>
    {
        ModelAutoService db;
        public DiscountRepositorySQL(ModelAutoService db) { this.db = db; }
        public void Create(Discount item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Discount GetItem(int id)
        {
            return db.Discounts.Find(id);
        }

        public List<Discount> GetList()
        {
            return db.Discounts.ToList();
        }

        public void Update(Discount item)
        {
            throw new NotImplementedException();
        }
    }
}
