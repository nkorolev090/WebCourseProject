using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using DomainModel;

namespace BLL.Services
{
    public class ClientService : IClientService
    {
        IDbRepository db;
        public ClientService(IDbRepository db) { this.db = db; }
        public bool CreateClientDTO(ClientDTO p)
        {
            throw new NotImplementedException();
        }

        public void DeleteClientDTO(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClientDTO> GetAllClientDTO()
        {
            throw new NotImplementedException();
        }

        public ClientDTO GetClientDTO(int id)
        {
            return new ClientDTO(db.Clients.GetItem(id));
        }

        public void UpdateClientDiscount(int id, int count)
        {
            Client client = db.Clients.GetItem(id);
            client.discount_points += count;
            if (client.discount_points >= 25000)
            {
                client.discount_id = 7;
            }
            else
            {
                if (client.discount_points >= 20000)
                {
                    client.discount_id = 4;
                }
                else
                {
                    if (client.discount_points >= 15000)
                    {
                        client.discount_id = 3;
                    }
                    else
                    {
                        if (client.discount_points >= 10000)
                        {
                            client.discount_id = 2;
                        }
                        else
                        {
                            if(client.discount_points >= 5000)
                            {
                                client.discount_id = 1;
                            }
                            else
                            {
                                client.discount_id = 0;
                            }
                        }
                    }
                }
            }
            client.Discount = db.Discouts.GetItem(client.discount_id);
            db.Save();
        }

        public void UpdateClientDTO(ClientDTO p)
        {
            throw new NotImplementedException();
        }

        public int GetClientDiscount(int id)
        {
            
            return db.Clients.GetItem(id).Discount.sale;
        }
    }
}
