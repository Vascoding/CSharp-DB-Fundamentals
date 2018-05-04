using System.Data.Entity.ModelConfiguration.Conventions;
using Photography.Models;

namespace Photography.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotographyContext : DbContext
    {
        public PhotographyContext()
            : base("name=PhotographyContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Photographer>().HasMany(p => p.Workshops).WithMany(w => w.Participants)
                .Map(pw =>
                {
                    pw.ToTable("PhotographerWorkshop");
                    pw.MapLeftKey("PhotographerId");
                    pw.MapRightKey("WorkshopId");
                });

            modelBuilder.Entity<Workshop>().HasRequired(w => w.Trainer).WithMany();

            modelBuilder.Entity<Len>().HasOptional(l => l.Photographer);
        }

        public virtual DbSet<Accessory> Accessories { get; set; }
        public virtual DbSet<Camera> Cameras { get; set; }
        public virtual DbSet<Len> Lens { get; set; }
        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<Workshop> Workshops { get; set; }

    }
}