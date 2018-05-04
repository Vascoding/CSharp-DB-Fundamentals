using System;
using System.Collections.Generic;


namespace TeamBuilder.Models
{
    public class Team
    {
        public Team()
        {
            this.Members = new HashSet<User>();
            this.ParticipadedEvents = new HashSet<Event>();
            this.InvitationsSend = new HashSet<Invitation>();
        }

        
        public int Id { get; set; }
        
        public string Name { get; set; }

        
        public string Description { get; set; }

        
        public string Acronym { get; set; }

        
        public int CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<User> Members { get; set; }

        public virtual ICollection<Event> ParticipadedEvents { get; set; }

        public virtual ICollection<Invitation> InvitationsSend { get; set; }
    }
}
