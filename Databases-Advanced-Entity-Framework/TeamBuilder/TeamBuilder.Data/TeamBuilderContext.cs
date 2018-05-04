using TeamBuilder.Data.Configuration;
using TeamBuilder.Models;

namespace TeamBuilder.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TeamBuilderContext : DbContext
    {
        
        public TeamBuilderContext()
            : base("name=TeamBuilderContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new TeamConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<Invitation> Invitations { get; set; }

        public virtual DbSet<Team> Teams { get; set; }
    }
}