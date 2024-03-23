namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mechanic-Breakdown")]
    public partial class Mechanic_Breakdown
    {
        public int id { get; set; }

        public int mechanic_id { get; set; }

        public int breakdown_id { get; set; }

        public virtual Breakdown Breakdown { get; set; }

        public virtual Mechanic Mechanic { get; set; }
    }
}
