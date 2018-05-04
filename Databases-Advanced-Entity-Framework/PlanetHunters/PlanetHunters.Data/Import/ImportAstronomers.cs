using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Data.Dtos;
using PlanetHunters.Models;

namespace PlanetHunters.Data
{
    public static class ImportAstronomers
    {
        public static void AddAstronommers(List<AstronomerDto> astronomers)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var a in astronomers)
                {
                    if (a.FirstName != null && a.FirstName.Length <= 50 && a.LastName != null && a.LastName.Length <= 50)
                    {
                        Astronomer astronomer = new Astronomer()
                        {
                            FirstName = a.FirstName,
                            LastName = a.LastName
                        };
                        context.Astronomers.Add(astronomer);
                        Console.WriteLine($"Record {astronomer.FirstName} {astronomer.LastName} successfully imported.");
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
