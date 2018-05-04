using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Data.Dtos;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Import
{
    public static class ImportStars
    {
        public static void AddStars(List<StarDto> stars)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var s in stars)
                {
                    var starSystem = context.StarSystems.FirstOrDefault(n => n.Name == s.StarSystem);
                    if (starSystem == null)
                    {
                        StarSystem newStarSystem = new StarSystem()
                        {
                            Name = s.StarSystem
                        };
                        context.StarSystems.Add(newStarSystem);
                        context.SaveChanges();
                    }

                    if (s.Name != null && s.Temperature > 2400 && !s.Temperature.Equals(null))
                    {
                        var starSys = context.StarSystems.FirstOrDefault(n => n.Name == s.StarSystem);
                        Star star = new Star()
                        {
                            Name = s.Name,
                            Temperature = s.Temperature,
                            StarSystem = starSys
                        };
                        context.Stars.Add(star);
                        Console.WriteLine($"Record {star.Name} successfully imported.");
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
