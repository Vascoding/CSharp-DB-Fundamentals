using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Export
{
    public static class ExportStars
    {
        public static void SendStars()
        {
           var context = new PlanetHuntersContext();
            var stars = context.Stars.Select(s => new
            {
                Name = s.Name,
                Temperature = s.Temperature,
                StarSystemName = s.StarSystem.Name,
                DiscovertDate = s.Discovery.DateMade,
                TelescopeName = s.Discovery.Telescope.Name,
                Astronomers = new
                {
                    Pioner = s.Discovery.Pioneers.Select(a => a.FirstName + " " + a.LastName)
                }
            });
        }
    }
}
