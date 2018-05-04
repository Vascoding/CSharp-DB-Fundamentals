using WeddingPlanner.Models;

namespace WeddingPlanner.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WeddingsPlannerContext : DbContext
    {
        public WeddingsPlannerContext()
            : base("name=WeddingsPlannerContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Present>()
                .HasKey(e => e.InvitationId);

            modelBuilder.Entity<Invitation>()
                .HasRequired(p => p.Present)
                .WithRequiredPrincipal(i => i.Invitation);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<Present> Presents { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Wedding> Weddings { get; set; }
    }

}