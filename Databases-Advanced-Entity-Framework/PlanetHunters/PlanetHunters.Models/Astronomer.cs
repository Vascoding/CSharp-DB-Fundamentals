using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
{
    public class Astronomer
    {
        public Astronomer()
        {
            this.PioneeringDiscoveries = new HashSet<Discovery>();
            this.ObservationDiscoveries = new HashSet<Discovery>();
        }

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [InverseProperty("Pioneers")]
        public virtual ICollection<Discovery> PioneeringDiscoveries { get; set; }

        [InverseProperty("Observers")]
        public virtual ICollection<Discovery> ObservationDiscoveries { get; set; }

    }
}
