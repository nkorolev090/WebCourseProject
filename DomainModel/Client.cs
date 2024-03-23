using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Client : User
{

    public int DiscountId { get; set; }

    public int DiscountPoints { get; set; }

    public DateTime BirthDate { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Discount Discount { get; set; } = null!;
}
