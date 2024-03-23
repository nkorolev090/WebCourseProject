using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Slot
{
    public int Id { get; set; }

    public int? BreakdownId { get; set; }

    public int MechanicId { get; set; }

    public TimeSpan StartTime { get; set; }

    public DateTime StartDate { get; set; }

    public TimeSpan FinishTime { get; set; }

    public DateTime FinishDate { get; set; }

    public int? RegistrationId { get; set; }

    public virtual Breakdown? Breakdown { get; set; }

    public virtual Mechanic Mechanic { get; set; } = null!;

    public virtual Registration? Registration { get; set; }
}
