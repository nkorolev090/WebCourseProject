using System;
using System.Collections.Generic;

namespace DomainModel;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DiscountId { get; set; }

    public int DiscountPoints { get; set; }

    public string Surname { get; set; } = null!;

    public string Midname { get; set; } = null!;

    public string TelNumber { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Discount Discount { get; set; } = null!;
}
