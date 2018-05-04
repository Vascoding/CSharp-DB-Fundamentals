using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Data.Dtos
{
    public class DiscoveryDto
    {
        public DateTime DateMade { get; set; }

        public string Telescope { get; set; }

        public List<XMLStarDto> Stars { get; set; }

        public List<PlanetDto> Planets { get; set; }

        public List<AstronomerDto> Pioneers { get; set; }
        public List<AstronomerDto> Observers { get; set; }
    }
}
