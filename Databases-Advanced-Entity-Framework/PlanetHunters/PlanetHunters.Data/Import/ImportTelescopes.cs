using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Data.Dtos;
using PlanetHunters.Models;

namespace PlanetHunters.Data.Import
{
    public static class ImportTelescopes
    {
        public static void AddTelescopes(List<TelescopeDto> telescopes)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var t in telescopes)
                {
                    if (t.Name != null && t.Location != null && t.MirrorDiameter > 0 && !t.MirrorDiameter.Equals(null))
                    {
                            Telescope telescope = new Telescope()
                            {
                                Name = t.Name,
                                Location = t.Location,
                                MirrorDiameter = t.MirrorDiameter
                            };
                            context.Telescopes.Add(telescope);
                            Console.WriteLine($"Record {telescope.Name} successfully imported.");
                        
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
