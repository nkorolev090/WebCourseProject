using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IDbRepository
    {
        IRepository<Client> Clients {  get; }
        IRepository<Car> Cars { get; }
        IRepository<Slot> Slots { get; }
        IRepository<Registration> Registrations { get; }
        IRepository<Breakdown> Breakdowns { get; }
        IRepository<Mechanic> Mechanics { get; }
        IRepository<Mechanic_Breakdown> Mechanic_Breakdowns {  get; }
        IRepository<Repair_Review> Repair_Reviews { get; }
        IRepository<Status> Statuses { get; }
        IRepository<Discount> Discouts {  get; }
        int Save();
    }
}
