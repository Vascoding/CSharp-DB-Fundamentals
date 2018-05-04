using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Data.Dtos
{
    public class TelescopeDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public double? MirrorDiameter { get; set; }
    }
}
