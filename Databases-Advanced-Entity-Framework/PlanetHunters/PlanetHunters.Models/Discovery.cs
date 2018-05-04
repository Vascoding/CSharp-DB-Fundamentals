using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
{
    public class Discovery
    {
        public Discovery()
        {
            this.Stars = new HashSet<Star>();
            this.Planets = new HashSet<Planet>();
            this.Pioneers = new HashSet<Astronomer>();
            this.Observers = new HashSet<Astronomer>();
            this.Publications = new HashSet<Publication>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime DateMade { get; set; }

        [Required]
        public int TelescopeId { get; set; }

        public Telescope Telescope { get; set; }

        public virtual ICollection<Star> Stars { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }

        public virtual ICollection<Astronomer> Pioneers { get; set; }

        public virtual ICollection<Astronomer> Observers { get; set; }

        public virtual ICollection<Publication> Publications { get; set; }
    }
}
