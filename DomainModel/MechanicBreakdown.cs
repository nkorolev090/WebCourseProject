using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class MechanicBreakdown
{
    public int Id { get; set; }

    public int MechanicId { get; set; }

    public int BreakdownId { get; set; }

    public virtual Breakdown Breakdown { get; set; } = null!;

    public virtual Mechanic Mechanic { get; set; } = null!;
}
