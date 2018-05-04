using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Data.Dtos;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Import
{
    public static class ImportPlanets
    {
        public static void AddPlanets(List<PlanetDto> planets)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var p in planets)
                {
                    var starStstem = context.StarSystems.FirstOrDefault(s => s.Name == p.StarSystem);
                    if (starStstem == null && p.StarSystem.Length < 255)
                    {
                        StarSystem starSystem = new StarSystem()
                        {
                            Name = p.StarSystem
                        };
                        context.StarSystems.Add(starSystem);
                        context.SaveChanges();
                    }
                    if (p.Name != null && p.Mass > 0.0)
                    {
                        
                        var starSystem = context.StarSystems.FirstOrDefault(s => s.Name == p.StarSystem);
                        Planet planet = new Planet()
                        {
                            Name = p.Name,
                            Mass = p.Mass,
                            StarSystem = starSystem
                        };
                        context.Planets.Add(planet);
                        Console.WriteLine($"Record {planet.Name} successfully imported.");
                    }

                    else
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
