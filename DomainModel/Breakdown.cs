using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Breakdown
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Info { get; set; }

    public int Price { get; set; }

    public int Warranty { get; set; }

    public virtual ICollection<MechanicBreakdown> MechanicBreakdowns { get; set; } = new List<MechanicBreakdown>();

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();
}
