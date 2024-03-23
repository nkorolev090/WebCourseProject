using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Car
{
    public int Id { get; set; }

    public string Model { get; set; } = null!;

    public int OwnerId { get; set; }

    public string Color { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public int Mileage { get; set; }

    public virtual Client Owner { get; set; } = null!;

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
