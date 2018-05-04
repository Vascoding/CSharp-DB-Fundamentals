using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
{
    public class Star
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        public int Temperature { get; set; }

        [Required]
        public int StarSystemId { get; set; }

        public virtual StarSystem StarSystem { get; set; }

        public int? DiscoveryId { get; set; }

        public Discovery Discovery { get; set; }
    }
}
