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
    public class ClientRepositorySQL : IRepository<Client>
    {
        ModelAutoService db;
        public ClientRepositorySQL(ModelAutoService db)
        {
            this.db = db;
        }
        public async Task<Client> CreateAsync(Client item)
        {
            db.Clients.Add(item);
            await db.SaveChangesAsync();
            return await db.Clients.LastAsync();
        }

        public async void DeleteAsync(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            if (client != null)
            {
                db.Clients.Remove(client);
            }
        }

        public async Task<Client>? GetItemAsync(int id)
        {
            return await db.Clients.FindAsync(id);
        }

        public async Task<List<Client>> GetListAsync()
        {
            return await db.Clients.ToListAsync();
        }

        public void Update(Client item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
