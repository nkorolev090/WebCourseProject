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
        IDbRepository db;
        public RegistrationService(IDbRepository db) { this.db = db; }
        public RegistrationDTO CreateRegistration(RegistrationDTO registration)//тип возвращаемого значения и логика слотов
        {
            Registration reg = new Registration();
            reg.car_id = registration.car_id;
            reg.reg_price = registration.reg_price;
            reg.info = registration.info;
            reg.review_id = registration.review_id;
            reg.reg_date = registration.reg_date;
            reg.status = registration.status;
            reg.Car = db.Cars.GetItem(registration.car_id);
            if(registration.review_id != null)
                reg.Repair_Review = db.Repair_Reviews.GetItem((int)registration.review_id);
            reg.Status1 = db.Statuses.GetItem(registration.status);
            db.Registrations.Create(reg);
            db.Save();

            return new RegistrationDTO(db.Registrations.GetList().Last());
            
        }
        public RegistrationDTO GetItem(int id)
        {
            return new RegistrationDTO(db.Registrations.GetItem(id));
        }

        public List<RegistrationDTO> GetClientRegistrations(int client_id)
        {
            return db.Registrations.GetList().Where(i => i.Car.owner_id == client_id).ToList().Select(i => new RegistrationDTO(i)).ToList();
        }

        public List<StatusDTO> GetStatuses()
        {
            return db.Statuses.GetList().Where(i => i.id < 5).Select(i => new StatusDTO(i)).ToList();
        }
        public StatusDTO GetStatus(int id)
        {
            return new StatusDTO(db.Statuses.GetItem(id));
        }

        public List<RegistrationDTO> GetMechanicRegistrations(int mechanic_id)
        {
            List<RegistrationDTO> regs = db.Slots.GetList().Where(i => i.registration_id != null && i.mechanic_id == mechanic_id).ToList().Select(i => new RegistrationDTO(i.Registration)).ToList();
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
        public void UpdateRegistration(RegistrationDTO registration)
        {
            if(registration.status == 3)//если заявка отклонена то необходимо освободить слоты
            {
                List<Slot> regSlots = db.Slots.GetList().Where(i=>i.registration_id == registration.id).ToList();
                foreach (Slot regSlot in regSlots)
                {
                    regSlot.registration_id = null;
                    regSlot.Registration = null;
                    regSlot.breakdown_id = null;
                    regSlot.Breakdown = null;
                }
                db.Save();
            }
            Registration reg = db.Registrations.GetItem(registration.id);
            reg.reg_price = registration.reg_price;
            reg.info = registration.info;
            reg.car_id = registration.car_id;
            reg.reg_date = registration.reg_date;
            reg.Car = db.Cars.GetItem(registration.car_id);
            reg.Slots = db.Slots.GetList().Where(i => i.registration_id == registration.id).ToList();
            reg.status = registration.status;
            reg.review_id = registration.review_id;
            if(registration.review_id != null) { reg.Repair_Review = db.Repair_Reviews.GetItem((int)registration.review_id); }
            
            reg.Status1 = db.Statuses.GetItem(registration.status);
            db.Save();

        }

        public void DeleteRegistration(int registration_id)
        {
            Registration registration = db.Registrations.GetItem(registration_id);
            foreach(Slot slot in  registration.Slots)
            {
              
                slot.Breakdown = null;
                slot.breakdown_id = null;
                slot.Registration = null;
                slot.registration_id = null;
            }
            db.Save();

            db.Registrations.Delete(registration_id);

            db.Save();
        }
    }
}
