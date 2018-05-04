using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingPlanner.Models
{
    
    public enum Family
    {
        Bride,
        BrideGroom
    }
    public class Invitation
    {
        public int Id { get; set; }

        public Wedding Wedding { get; set; }

        [Required]
        public Person Guest { get; set; }

        public Present Present { get; set; }

        public bool Attending { get; set; }

        [Required]
        public Family Family { get; set; }
    }
}
