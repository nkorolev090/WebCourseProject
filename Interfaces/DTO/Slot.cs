using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class SlotDTO
    {
        public int id { get; set; }

        public int? breakdown_id { get; set; }
        public string breakdown_name { get; set; } 
        public int breakdown_warranty { get; set; }
        public int cost {  get; set; }

        public int mechanic_id { get; set; }

        public string mechanic_name {  get; set; }

        public TimeSpan start_time { get; set; }

        public DateTime start_date { get; set; }

        public TimeSpan finish_time { get; set; }

        public DateTime finish_date { get; set; }

        public int? registration_id { get; set; }

        public SlotDTO(Slot slot)
        {
            this.id = slot.Id;
            this.breakdown_id = slot.BreakdownId;
            if( slot.BreakdownId != null )
            {
                this.breakdown_name = slot.Breakdown.Title;
                this.breakdown_warranty = slot.Breakdown.Warranty;
                this.cost = slot.Breakdown.Price;
            }
            
            this.mechanic_id = slot.MechanicId;
            this.mechanic_name = slot.Mechanic.Surname + " " + slot.Mechanic.Name[0] + ". " + slot.Mechanic.Midname[0] + ".";
            this.start_time = slot.StartTime;
            this.start_date = slot.StartDate;
            this.finish_time = slot.FinishTime;
            this.finish_date = slot.FinishDate;
            this.registration_id = slot.RegistrationId;
        }
        public SlotDTO() { }
    }
}
