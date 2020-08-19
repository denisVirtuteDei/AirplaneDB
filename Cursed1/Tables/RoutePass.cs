namespace Cursed1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoutePass")]
    public partial class RoutePass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoutePass()
        {
            Flights = new HashSet<Flights>();
            Tickets = new HashSet<Tickets>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_Route { get; set; }

        [Required]
        [StringLength(30)]
        public string DeparturePoint { get; set; }

        [Required]
        [StringLength(30)]
        public string ArrivalPoint { get; set; }

        [Column(TypeName = "date")]
        public DateTime DepartureDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ArrivalDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flights> Flights { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
