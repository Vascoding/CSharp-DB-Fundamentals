using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        public Wedding()
        {
            this.Venues = new HashSet<Venue>();
            this.Invitations = new HashSet<Invitation>();
        }
        public int Id { get; set; }

        [ForeignKey("Bride")]
        public int? BrideId { get; set; }

        [ForeignKey("Bridegroom")]
        public int? BridegroomId { get; set; }

        public Person Bride { get; set; }

        public Person Bridegroom { get; set; }

        public DateTime Date { get; set; }

        public virtual Agency Agency { get; set; }

        public virtual ICollection<Venue> Venues { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }

    }
}
