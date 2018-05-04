using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class User
    {
        public User()
        {
            this.CreatedEvents = new HashSet<Event>();
            this.Teams = new HashSet<Team>();
            this.CreatedTeams = new HashSet<Team>();
            this.RecievedInvitations = new HashSet<Invitation>();
        }

        
        public int Id { get; set; }

        
        public string Username { get; set; }

        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string Password { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Event> CreatedEvents { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<Team> CreatedTeams { get; set; }

        public virtual ICollection<Invitation> RecievedInvitations { get; set; }


    }
}
