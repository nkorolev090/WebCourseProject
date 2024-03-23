using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Discount
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Sale { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
