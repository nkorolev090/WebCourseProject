using DomainModel;
using Interfaces.DTO;
using Interfaces.Models;
using Interfaces.Repository;
using Interfaces.Services;
using System.Security.Claims;

namespace BLL.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IDbRepository db;
        private readonly IUserService userService;
        private readonly ICartService cartService;
        private readonly INotificationService notificationService;
        private readonly IDeviceTokenService deviceTokenService;
        public RegistrationService(IDbRepository db, IUserService userService, ICartService cartService, INotificationService notificationService, IDeviceTokenService deviceTokenService) 
        { 
            this.db = db;
            this.userService = userService;
            this.cartService = cartService;
            this.notificationService = notificationService;
            this.deviceTokenService = deviceTokenService;
        }
        public async Task<RegistrationDTO?> CreateRegistrationAsync(RegistrationViewModel registration, ClaimsPrincipal currUser)//Метод создания записи
        {

            UserDTO? user = await userService.IsAuthenticatedAsync(currUser);
            var client = await db.Clients.GetItemAsync(user!.Client!.id);
            if (user == null || client == null)
            {
                return null;
            }

            Registration reg = new Registration();
            reg.CarId = registration.Registration.car_id;

            var price = await sumSubTotal(registration.Slots);
            price *= 1.0 - client.Discount.Sale / 100.0;
            reg.RegPrice = price;

            reg.Info = registration.Registration.info;
            reg.RegDate = DateTime.Now;
            reg.Status = 1; //на обработке
            reg.Car = await db.Cars.GetItemAsync(registration.Registration.car_id);
            reg.StatusNavigation = await db.Statuses.GetItemAsync(1);
            Registration registration1 = await db.Registrations.CreateAsync(reg);

            await db.SaveAsync();

            foreach(SlotDTO slot in registration.Slots)
            {
                var s = await db.Slots.GetItemAsync(slot.id);
                if(s == null)
                {
                    return null;
                }
                s.RegistrationId = registration1.Id;
                s.Registration = registration1;
            }

            await db.SaveAsync();

            await cartService.ClearCart(currUser);

            return new RegistrationDTO(registration1);
            
        }

        private async Task<double> sumSubTotal(ICollection<SlotDTO> slotItems)
        {
            var sum = 0.0;
            foreach (SlotDTO slotDTO in slotItems)
            {
                var slot = await db.Slots.GetItemAsync(slotDTO.id);
                if(slot != null)
                {
                    sum += slot.Breakdown!.Price;
                }
            }
            return sum;
        }

        public async Task<RegistrationDTO> GetItemAsync(int id)//Метод возвращающий запись по id
        {
            Registration registration = await db.Registrations.GetItemAsync(id);
            if(registration == null) { return null; }
            return new RegistrationDTO(registration);
        }

        public async Task<List<RegistrationDTO>?> GetRegistrationsAsync(ClaimsPrincipal currUser)//Метод возвращающий все записи текущего пользователя
        {
            UserDTO? user = await userService.IsAuthenticatedAsync(currUser);

            if(user?.Client != null)
            {
                return await GetClientRegistrationsAsync(user.Client.id);
            }
            else
            {
                if(user?.Mechanic != null)
                {
                    return await GetMechanicRegistrationsAsync(user.Mechanic.id);
                }
                else
                {
                    return null;
                }
            }
        }
        private async Task<List<RegistrationDTO>> GetClientRegistrationsAsync(int client_id) {//Метод возвращающий все записи пользователя как клиента

            List<Registration> list = await db.Registrations.GetListAsync();
            return list.Where(i => i.Car.OwnerId == client_id).ToList().Select(i => new RegistrationDTO(i)).ToList();
        }

        public async Task<List<StatusDTO>> GetStatusesAsync()
        {
            List<Status> list = await db.Statuses.GetListAsync();
            return list.Where(i => i.Id < 5).Select(i => new StatusDTO(i)).ToList();
        }
        public async Task<StatusDTO> GetStatusAsync(int id)
        {
            Status status = await db.Statuses.GetItemAsync(id);
            return new StatusDTO(status);
        }

        private async Task<List<RegistrationDTO>> GetMechanicRegistrationsAsync(int mechanic_id)//Метод возвращающий все записи пользователя как механика
        {
            List<Slot> _regs = await db.Slots.GetListAsync();
            List<RegistrationDTO> regs = _regs.Where(i => i.RegistrationId != null && i.MechanicId == mechanic_id).ToList().Select(i => new RegistrationDTO(i.Registration)).ToList();
            
            List<RegistrationDTO> regsRet = new List<RegistrationDTO>();
            foreach (var reg in regs)
            {
                if (!regsRet.Any(i => i.id == reg.id))
                {
                    regsRet.Add(reg);
                }
            }
            return regsRet;
        }

        public async Task<int> UpdateRegistrationAsync(RegistrationDTO registration, ClaimsPrincipal currUser)//Метод обновления записи
        {
            if(registration.status == 3)//если заявка отклонена то необходимо освободить слоты
            {
                List<Slot> _regSlots = await db.Slots.GetListAsync();
                List<Slot> regSlots = _regSlots.Where(i=>i.RegistrationId == registration.id).ToList();
                foreach (Slot regSlot in regSlots)
                {
                    regSlot.RegistrationId = null;
                    regSlot.Registration = null;
                    regSlot.BreakdownId = null;
                    regSlot.Breakdown = null;
                }  
            }
            Registration reg = await db.Registrations.GetItemAsync(registration.id);
            reg.Info = registration.info;
            reg.CarId = registration.car_id;
            reg.Car = await db.Cars.GetItemAsync(registration.car_id);
            List<Slot> _slots = await db.Slots.GetListAsync();
            reg.Slots = _slots.Where(i => i.RegistrationId == registration.id).ToList();
            reg.Status = (int)registration.status;            
            reg.StatusNavigation = await db.Statuses.GetItemAsync(reg.Status);

            UserDTO? user = await userService.IsAuthenticatedAsync(currUser);
            if (user?.Mechanic!= null && reg.Status > 1 && reg.Status < 5)
            {
                var ownerUserId = reg?.Car?.Owner.Users.FirstOrDefault()?.Id;
                if (ownerUserId == null) return 115;

                var deviceTokens = await deviceTokenService.GetUsersDeviceTokensAsync(ownerUserId);
                if (deviceTokens == null) return 33;

                var notificationRoot = NotificationType.REG_STATUS_UPDATE.toNotificationRoot(reg);

                List<Task> tasks = new List<Task>();
                foreach (var deviceToken in deviceTokens)
                {
                    notificationRoot.message.token = deviceToken.token;
                    tasks.Add(notificationService.SendNotification(notificationRoot));
                }

                await Task.WhenAll(tasks);
            }

            return await db.SaveAsync();
        }

        public async Task<int> CloseRegistrationAsync(int registrationId, ClaimsPrincipal currUser)
        {
            UserDTO? user = await userService.IsAuthenticatedAsync(currUser);

                Registration? registration = await db.Registrations.GetItemAsync(registrationId);

            if (registration == null) return 1;

            if (registration.Car.Owner.Id == user?.Client?.id || user?.Mechanic != null)
            {
                List<Slot> _regSlots = await db.Slots.GetListAsync();
                List<Slot> regSlots = _regSlots.Where(i => i.RegistrationId == registration.Id).ToList();
                foreach (Slot regSlot in regSlots)
                {
                    regSlot.RegistrationId = null;
                    regSlot.Registration = null;
                    regSlot.BreakdownId = null;
                    regSlot.Breakdown = null;
                }

                registration.Status = 3;
                registration.StatusNavigation = await db.Statuses.GetItemAsync(3);

                return await db.SaveAsync();
            }

            if (user?.Mechanic != null)
            {
                var ownerUserId = registration.Car.Owner.Users.FirstOrDefault()?.Id;
                if (ownerUserId == null) return 115;

                var deviceTokens = await deviceTokenService.GetUsersDeviceTokensAsync(ownerUserId);
                if (deviceTokens == null) return 33;

                var notificationRoot = NotificationType.REG_STATUS_UPDATE.toNotificationRoot(registration);

                List<Task> tasks = new List<Task>();
                foreach (var deviceToken in deviceTokens)
                {
                    notificationRoot.message.token = deviceToken.token;
                    tasks.Add(notificationService.SendNotification(notificationRoot));
                }
            }
            return 3;
        }

        public async Task<bool> DeleteRegistrationAsync(int registration_id)//Метод удаления записи
        {
            Registration registration = await db.Registrations.GetItemAsync(registration_id);
            if (registration == null)
            {
                return false;
            }
            foreach(Slot slot in  registration.Slots)
            {
              
                slot.Breakdown = null;
                slot.BreakdownId = null;
                slot.Registration = null;
                slot.RegistrationId = null;
            }
            await db.SaveAsync();

            db.Registrations.DeleteAsync(registration_id);

            await db.SaveAsync();
            return true;
        }
    }
}
