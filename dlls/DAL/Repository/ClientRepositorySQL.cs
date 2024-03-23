using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Interfaces.Repository;

namespace DAL.Repository
{
    public class ClientRepositorySQL : IRepository<Client>
    {
        ModelAutoService db;
        public ClientRepositorySQL(ModelAutoService db)
        {
            this.db = db;
        }
        public void Create(Client item)
        {
            db.Clients.Add(item);
        }

        public void Delete(int id)
        {
           Client client = db.Clients.Find(id);
            if(client != null)
            {
                db.Clients.Remove(client);
            }
        }

        public Client GetItem(int id)
        {
           return db.Clients.Find(id);
        }

        public List<Client> GetList()
        {
            return db.Clients.ToList();
        }

        public void Update(Client item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
