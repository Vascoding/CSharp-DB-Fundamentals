using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Export
{
    public static class ExportPlanets
    {
        public static IEnumerable<Planet> SendPlanets(string telescope)
        {
            var context = new PlanetHuntersContext();
            return context.Planets.Where(t => t.Discovery.Telescope.Name == telescope).OrderByDescending(p => p.Mass);
        }
    }
}
