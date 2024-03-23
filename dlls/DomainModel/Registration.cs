namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registration")]
    public partial class Registration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registration()
        {
            Slots = new HashSet<Slot>();
        }

        public int id { get; set; }

        public int car_id { get; set; }

        [StringLength(255)]
        public string info { get; set; }

        public int status { get; set; }

        public int? review_id { get; set; }

        public int? reg_price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? reg_date { get; set; }

        public virtual Car Car { get; set; }

        public virtual Repair_Review Repair_Review { get; set; }

        public virtual Status Status1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
