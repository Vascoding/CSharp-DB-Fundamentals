using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
{
    public class Publication
    {
        public int Id { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int DiscoveryId { get; set; }

        public Discovery Discovery { get; set; }

        public int JurnalId { get; set; }

        public Jurnal Jurnal { get; set; }
    }
}
