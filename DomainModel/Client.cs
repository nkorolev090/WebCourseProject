using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Client
{
    public int Id { get; set; }

    public int DiscountId { get; set; }

    public int DiscountPoints { get; set; }

    public DateTime? BirthDate { get; set; } = null!;

    public int? CartId { get; set; }

    public virtual Cart? Cart { get; set; } = null;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Discount Discount { get; set; } = null!;
}
