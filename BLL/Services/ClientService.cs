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
        public async Task<ClientDTO> CreateClientDTOAsync(ClientDTO p)
        {
            Client client = new Client();
            client.DiscountId = 1;
            client.Discount = await db.Discouts.GetItemAsync(1);
            client.DiscountPoints = 0;
            
            return new ClientDTO(await db.Clients.CreateAsync(client));
        }

        public void DeleteClientDTOAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientDTO>> GetAllClientDTOAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ClientDTO> GetClientDTOAsync(int id)
        {
            Client client = await db.Clients.GetItemAsync(id);
            return new ClientDTO(client);
        }

        public async void UpdateClientDiscountAsync(int id, int count)
        {
            Client client = await db.Clients.GetItemAsync(id);
            client.DiscountPoints += count;
            if (client.DiscountPoints >= 25000)
            {
                client.DiscountId = 7;
            }
            else
            {
                if (client.DiscountPoints >= 20000)
                {
                    client.DiscountId = 4;
                }
                else
                {
                    if (client.DiscountPoints >= 15000)
                    {
                        client.DiscountId = 3;
                    }
                    else
                    {
                        if (client.DiscountPoints >= 10000)
                        {
                            client.DiscountId = 2;
                        }
                        else
                        {
                            if(client.DiscountPoints >= 5000)
                            {
                                client.DiscountId = 1;
                            }
                            else
                            {
                                client.DiscountId = 0;
                            }
                        }
                    }
                }
            }
            client.Discount = await db.Discouts.GetItemAsync(client.DiscountId);
            await db.SaveAsync();
        }

        public void UpdateClientDTOAsync(ClientDTO p)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetClientDiscountAsync(int id)
        {
            Client client = await db.Clients.GetItemAsync(id);
            return  client.Discount.Sale;
        }
    }
}
