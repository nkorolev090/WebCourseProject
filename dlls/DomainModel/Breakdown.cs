namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Breakdown")]
    public partial class Breakdown
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Breakdown()
        {
            Mechanic_Breakdown = new HashSet<Mechanic_Breakdown>();
            Slots = new HashSet<Slot>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [StringLength(500)]
        public string info { get; set; }

        public int price { get; set; }

        public int warranty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mechanic_Breakdown> Mechanic_Breakdown { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
