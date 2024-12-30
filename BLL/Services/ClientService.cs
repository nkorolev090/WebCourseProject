using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using DomainModel;
using System.Security.Claims;

namespace BLL.Services
{
    public class ClientService : IClientService
    {
        IDbRepository db;
        IUserService userService;
        public ClientService(IDbRepository db, IUserService userService) 
        { 
            this.db = db;
            this.userService = userService;
        }
        public async Task<ClientDTO> CreateClientDTOAsync(ClientDTO p)
        {
            Client client = new Client();
            client.DiscountId = 1;
            client.Discount = await db.Discouts.GetItemAsync(1);
            client.DiscountPoints = 0;
            
            return new ClientDTO(await db.Clients.CreateAsync(client));
        }

        public async Task<ClientDTO?> SetDefaultStation(int id, ClaimsPrincipal currUser)
        {
            UserDTO? user = await userService.IsAuthenticatedAsync(currUser);
            if (user != null && user.Client != null)
            {
                var client = await db.Clients.GetItemAsync(user.Client.id);
                if (client == null) return null;

                client.DefaultStationId = id;
                db.Clients.Update(client);
                await db.SaveAsync();
                client = await db.Clients.GetItemAsync(client.Id);
                return client == null ? null : new ClientDTO(client);
            }
            return null;
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
