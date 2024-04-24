using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using System.Security.Claims;

namespace BLL.Services
{
    public class CarService : ICarService
    {
        private readonly IDbRepository db;
        private readonly IUserService userService;
        public CarService(IDbRepository db, IUserService userService) { this.db = db; this.userService = userService; }

        public async void CreateCarDTOAsync(CarDTO p)
        {
            Client owner = await db.Clients.GetItemAsync(p.owner_id);
            await db.Cars.CreateAsync(new Car() { Id = p.id, Brand = p.brand, Color = p.color, Model = p.model, Mileage = p.mileage, OwnerId = p.owner_id, Owner = owner, Registrations = null });
            await db.SaveAsync();
        }

        public async void DeleteCarDTOAsync(int id)
        {
            db.Cars.DeleteAsync(id);
            await db.SaveAsync();
        }

        public async Task<List<CarDTO>> GetAllCarDTOAsync()
        {
            List<Car> cars = await db.Cars.GetListAsync();
           return cars.Select(i => new CarDTO(i)).ToList();
        }

        public async Task<List<CarDTO>?> GetAllClientCarDTOAsync(ClaimsPrincipal currUser)
        {
            UserDTO? user = await userService.IsAuthenticatedAsync(currUser);

            if (user?.Client != null)
            {
                List<Car> cars = await db.Cars.GetListAsync();
                return cars.Where(i => i.OwnerId == user?.Client.id).Select(a => new CarDTO(a)).ToList();
            }

            return null;
        }
        public async Task<CarDTO> GetCarDTOAsync(int id)
        {
            Car car = await db.Cars.GetItemAsync(id);
            return new CarDTO(car);
        }

        public async void UpdateCarDTOAsync(CarDTO p)
        {
            Car car =  await db.Cars.GetItemAsync(p.id);
            car.Model = p.model;
            car.Brand = p.brand;
            car.Color = p.color;
            car.Mileage = p.mileage;
            car.OwnerId = p.owner_id;
            car.Owner = await db.Clients.GetItemAsync(p.owner_id);
            await db.SaveAsync();
        }
    }
}
