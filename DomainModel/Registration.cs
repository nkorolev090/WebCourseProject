using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DomainModel;

public partial class Registration
{
    public int Id { get; set; }

    public int CarId { get; set; }

    public string? Info { get; set; }

    public int Status { get; set; }
    
    public double? RegPrice { get; set; }

    public DateTime? RegDate { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();

    public virtual Status StatusNavigation { get; set; } = null!;
}
