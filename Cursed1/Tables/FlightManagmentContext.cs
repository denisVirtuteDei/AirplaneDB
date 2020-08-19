namespace Cursed1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FlightManagmentContext : DbContext
    {
        public FlightManagmentContext() : base("name=Model1") { }

        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<Passengers> Passengers { get; set; }
        public virtual DbSet<RoutePass> RoutePass { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flights>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Flights)
                .HasForeignKey(e => e.FK_Flight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Passengers>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Passengers)
                .HasForeignKey(e => e.FK_Passenger)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoutePass>()
                .HasMany(e => e.Flights)
                .WithRequired(e => e.RoutePass)
                .HasForeignKey(e => e.FK_Route)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoutePass>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.RoutePass)
                .HasForeignKey(e => e.FK_Route)
                .WillCascadeOnDelete(false);
        }
    }
}
