namespace Cursed1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tickets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_Ticket { get; set; }

        public int FK_Passenger { get; set; }

        public int FK_Flight { get; set; }

        public int FK_Route { get; set; }

        public virtual Flights Flights { get; set; }

        public virtual Passengers Passengers { get; set; }

        public virtual RoutePass RoutePass { get; set; }
    }
}
