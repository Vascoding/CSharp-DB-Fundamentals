using PlanetHunters.Models;

namespace PlanetHunters.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PlanetHuntersContext : DbContext
    {
        public PlanetHuntersContext()
            : base("name=PlanetHuntersContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Astronomer>()
                .HasMany(a => a.PioneeringDiscoveries)
                .WithMany(p => p.Pioneers)
                .Map(ap =>
                {
                    ap.ToTable("PioneersDiscoveries");
                    ap.MapLeftKey("AstronomerId");
                    ap.MapRightKey("DiscoverieId");
                });

            modelBuilder.Entity<Astronomer>()
                .HasMany(a => a.ObservationDiscoveries)
                .WithMany(o => o.Observers)
                .Map(ao =>
                {
                    ao.ToTable("ObserversDiscoveries");
                    ao.MapLeftKey("AstronomerId");
                    ao.MapRightKey("DiscoveryId");
                });
        }

        public virtual DbSet<Astronomer> Astronomers { get; set; }

        public DbSet<Discovery> Discoveries { get; set; }

        public DbSet<Planet> Planets { get; set; }

        public DbSet<Star> Stars { get; set; }

        public DbSet<StarSystem> StarSystems { get; set; }

        public DbSet<Telescope> Telescopes { get; set; }
        
    }
}