using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configuration
{
    class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            this.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(e => e.Description)
                .HasMaxLength(250);

            this.HasRequired(e => e.Creator)
                .WithMany(e => e.CreatedEvents);

            this.HasMany(e => e.ParticipatingTeams)
                .WithMany(t => t.ParticipadedEvents)
                .Map(et =>
                {
                    et.MapLeftKey("EventId");
                    et.MapRightKey("TeamId");
                    et.ToTable("EventTeams");
                });
        }
    }
}
