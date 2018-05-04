using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
{
    public class StarSystem
    {
        public StarSystem()
        {
            this.Planets = new HashSet<Planet>();
            this.Stars = new HashSet<Star>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }

        public virtual ICollection<Star> Stars { get; set; }
    }
}
