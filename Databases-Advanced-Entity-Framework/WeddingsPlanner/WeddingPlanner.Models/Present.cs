using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingPlanner.Models
{
    public class Present
    {
        
        public int InvitationId { get; set; }
        [NotMapped]
        public Person Owner { get { return this.Invitation.Guest; } }
        public virtual Invitation Invitation { get; set; }
    }
}
