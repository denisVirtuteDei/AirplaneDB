namespace Cursed1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Passengers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Passengers()
        {
            Tickets = new HashSet<Tickets>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_Passenger { get; set; }

        [Required]
        [StringLength(20)]
        public string Surname { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string FatherName { get; set; }

        [StringLength(30)]
        public string PasAddress { get; set; }

        [StringLength(10)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(20)]
        public string E_mail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
