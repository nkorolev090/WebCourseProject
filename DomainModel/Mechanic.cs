using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Mechanic
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public virtual ICollection<MechanicBreakdown> MechanicBreakdowns { get; set; } = new List<MechanicBreakdown>();

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
