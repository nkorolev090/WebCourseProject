using DomainModel;

namespace Interfaces.DTO
{
    public class MechanicDTO
    {
        public int id { get; set; }

        public string full_name { get; set; }

        public int station_id { get; set; }

        public MechanicDTO(Mechanic mechanic) 
        { 
            id = mechanic.Id;
            full_name = mechanic.FullName;
            station_id = mechanic.StationId;
        }
    }
}
