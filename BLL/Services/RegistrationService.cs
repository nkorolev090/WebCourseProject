using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IDbRepository db;
        public RegistrationService(IDbRepository db) { this.db = db; }
        public async Task<RegistrationDTO> CreateRegistrationAsync(RegistrationDTO registration)//тип возвращаемого значения и логика слотов
        {
            Registration reg = new Registration();
            reg.CarId = registration.car_id;
            reg.RegPrice = registration.reg_price;
            reg.Info = registration.info;
            reg.RegDate = registration.reg_date;
            reg.Status = registration.status;
            reg.Car = await db.Cars.GetItemAsync(registration.car_id);
            reg.StatusNavigation = await db.Statuses.GetItemAsync(registration.status);
            Registration registration1 = await db.Registrations.CreateAsync(reg);
            return new RegistrationDTO(registration1);
            
        }
        public async Task<RegistrationDTO> GetItemAsync(int id)
        {
            Registration registration = await db.Registrations.GetItemAsync(id);
            if(registration == null) { return null; }
            return new RegistrationDTO(registration);
        }

        public async Task<List<RegistrationDTO>> GetClientRegistrationsAsync(int client_id) {

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

        public async Task<List<RegistrationDTO>> GetMechanicRegistrationsAsync(int mechanic_id)
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
        public async Task<int> UpdateRegistrationAsync(RegistrationDTO registration)
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
            reg.RegPrice = registration.reg_price;
            reg.Info = registration.info;
            reg.CarId = registration.car_id;
            reg.RegDate = registration.reg_date;
            reg.Car = await db.Cars.GetItemAsync(registration.car_id);
            List<Slot> _slots = await db.Slots.GetListAsync();
            reg.Slots = _slots.Where(i => i.RegistrationId == registration.id).ToList();
            reg.Status = registration.status;            
            reg.StatusNavigation = await db.Statuses.GetItemAsync(registration.status);
            return await db.SaveAsync();

        }

        public async Task<bool> DeleteRegistrationAsync(int registration_id)
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
