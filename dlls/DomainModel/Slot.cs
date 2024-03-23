namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slot")]
    public partial class Slot
    {
        public int id { get; set; }

        public int? breakdown_id { get; set; }

        public int mechanic_id { get; set; }

        public TimeSpan start_time { get; set; }

        [Column(TypeName = "date")]
        public DateTime start_date { get; set; }

        public TimeSpan finish_time { get; set; }

        [Column(TypeName = "date")]
        public DateTime finish_date { get; set; }

        public int? registration_id { get; set; }

        public virtual Breakdown Breakdown { get; set; }

        public virtual Mechanic Mechanic { get; set; }

        public virtual Registration Registration { get; set; }
    }
}
