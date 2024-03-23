using DomainModel;
using Interfaces.DTO;
using Interfaces.Repository;
using Interfaces.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SlotService : ISlotService
    {
        IDbRepository db;
        public SlotService(IDbRepository db) { this.db = db; }
        public async Task<SlotDTO> CreateSlotAsync(SlotDTO slotDTO)
        {
            Slot slot = new Slot();
            slot.StartDate = slotDTO.start_date;
            slot.StartTime = slotDTO.start_time;
            slot.RegistrationId = slotDTO.registration_id;
            if(slot.RegistrationId != null)
            {
                slot.Registration = await db.Registrations.GetItemAsync((int)slot.RegistrationId);
            }
            slot.BreakdownId = slotDTO.breakdown_id;
            if(slot.BreakdownId != null)
            {
                slot.Breakdown = await db.Breakdowns.GetItemAsync((int) slot.BreakdownId);
            }
            slot.MechanicId = slotDTO.mechanic_id;

            slot.Mechanic = await db.Mechanics.GetItemAsync((int)slot.MechanicId);
            
            Slot _slot = await db.Slots.CreateAsync(slot);
            return new SlotDTO(_slot);
        }
        public async Task<List<SlotDTO>> GetAllSlotsAsync()
        {
            List<Slot> slots = await db.Slots.GetListAsync();
           return slots.Where(i => i.RegistrationId == null).Select( i => new SlotDTO(i)).ToList();
        }

        public async Task<List<SlotDTO>> GetSlotsByDate_BreakdownAsync(DateTime startDate, int breakdown_id) 
        {
            List<MechanicBreakdown> _mb = await db.Mechanic_Breakdowns.GetListAsync();
            List<int> mechanic_ids = _mb.Where(i => i.BreakdownId == breakdown_id).Select(i=>i.MechanicId).ToList();
            List<Slot> _slots = await db.Slots.GetListAsync();
            List<DateTime> dateTimes = _slots.Select(i => i.StartDate).ToList();
           
            return _slots.Where(i => i.StartDate == startDate && i.BreakdownId == null).Where(i=> mechanic_ids.Contains(i.MechanicId)).Select(i => new SlotDTO(i)).ToList();
        }

        public async Task<List<SlotDTO>> GetRegistrationSlotsAsync(int regId)
        {
            List<Slot> _slots = await db.Slots.GetListAsync();
            return _slots.Where(i => i.RegistrationId == regId).Select(i => new SlotDTO(i)).ToList();
        }
        public async Task<Dictionary<string, int>> GetCarSlotsReportAsync(int carId)
        {
            List<Slot> _slots = await db.Slots.GetListAsync();
            List<SlotDTO> carSlots = _slots.Where(i =>i.RegistrationId != null && i.Registration.CarId == carId).Select(i => new SlotDTO(i)).ToList();
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach(SlotDTO carSlot in carSlots)
            {
                if (dictionary.ContainsKey(carSlot.breakdown_name))
                {
                    dictionary[carSlot.breakdown_name] += 1;
                }
                else
                {
                    dictionary.Add(carSlot.breakdown_name, 1);
                }
            }
            return dictionary;
        }
        public async Task<Dictionary<string, int>> GetMechanicSlotsReportAsync(int mechanicId, string mounths)
        {
            int mnth;
            switch (mounths)
            {
                case "Месяц":
                    mnth = 1; break;
                case "Квартал":
                    mnth = 3; break;
                case "Полгода":
                    mnth = 6; break;
                case "Год":
                    mnth = 12; break;
                default:
                    mnth = 0; break;

            }
            List<SlotDTO> mSlots;
            if (mnth == 0)
            {
                List<Slot> _slots = await db.Slots.GetListAsync();
                mSlots = _slots.Where(i =>i.RegistrationId != null && i.Registration.Status == 4 && i.MechanicId == mechanicId).Select(i => new SlotDTO(i)).ToList();
            }
            else
            {
                DateTime reportDate = DateTime.Now.AddMonths(-mnth);
                List<Slot> _slots = await db.Slots.GetListAsync();
                mSlots = _slots.Where(i => i.RegistrationId != null && i.Registration.Status == 4 && i.MechanicId == mechanicId && i.StartDate > reportDate).Select(i => new SlotDTO(i)).ToList();
            }
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (SlotDTO mSlot in mSlots)
            {
                if (dictionary.ContainsKey(mSlot.breakdown_name))
                {
                    dictionary[mSlot.breakdown_name] += 1;
                }
                else
                {
                    dictionary.Add(mSlot.breakdown_name, 1);
                }
            }
            return dictionary;
        }
        public async Task<SlotDTO> GetSlotAsync(int id)
        {
            Slot _slot = await db.Slots.GetItemAsync(id);
            return new SlotDTO(_slot);
        }

        public async void UpdateSlotAsync(SlotDTO slot)
        {
            Slot s = await db.Slots.GetItemAsync(slot.id);
            s.StartTime = slot.start_time;
            s.StartDate = slot.start_date;
            s.FinishDate = slot.finish_date;
            s.FinishTime = slot.finish_time;
            s.MechanicId = slot.mechanic_id;
            s.BreakdownId = slot.breakdown_id;
            s.Mechanic = await db.Mechanics.GetItemAsync(slot.mechanic_id);
            if(slot.breakdown_id != null) { 
                s.Breakdown = await db.Breakdowns.GetItemAsync((int)slot.breakdown_id);
            }
            s.RegistrationId = slot.registration_id;
            if(slot.registration_id != null)
            {
                s.Registration = await db.Registrations.GetItemAsync((int)slot.registration_id);
            }
            await db.SaveAsync();
        }
    }
}
