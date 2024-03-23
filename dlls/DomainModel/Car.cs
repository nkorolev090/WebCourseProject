namespace DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            Registrations = new HashSet<Registration>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string model { get; set; }

        public int owner_id { get; set; }

        [Required]
        [StringLength(50)]
        public string color { get; set; }

        [Required]
        [StringLength(50)]
        public string brand { get; set; }

        public int mileage { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
