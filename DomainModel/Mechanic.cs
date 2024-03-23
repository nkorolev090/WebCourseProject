using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Mechanic
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Midname { get; set; } = null!;

    public string TelNumber { get; set; } = null!;

    public virtual ICollection<MechanicBreakdown> MechanicBreakdowns { get; set; } = new List<MechanicBreakdown>();

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
