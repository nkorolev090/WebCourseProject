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
        public string? breakdown_name { get; set; } 
        public int? breakdown_warranty { get; set; }
        public double? cost {  get; set; }

        public int mechanic_id { get; set; }

        public string? mechanic_name {  get; set; }

        public string? start_time { get; set; }

        public string? start_date { get; set; }

        public string? finish_time { get; set; }

        public string? finish_date { get; set; }

        public int? registration_id { get; set; }

        public SlotDTO(Slot slot)
        {
            this.id = slot.Id;
            this.breakdown_id = slot.BreakdownId;
            if( slot.BreakdownId != null )
            {
                this.breakdown_name = slot.Breakdown?.Title;
                this.breakdown_warranty = slot.Breakdown?.Warranty;
                this.cost = slot.Breakdown?.Price;
            }
            
            this.mechanic_id = slot.MechanicId;
            this.mechanic_name = slot.Mechanic.FullName;
            this.start_time = slot.StartTime.ToString();
            this.start_date = slot.StartDate.ToShortDateString();
            this.finish_time = slot.FinishTime.ToString();
            this.finish_date = slot.FinishDate.ToShortDateString();
            this.registration_id = slot.RegistrationId;
        }
        public SlotDTO() { }
    }
}
