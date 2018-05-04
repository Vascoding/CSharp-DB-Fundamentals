using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlanetHunters.Data.Export;
using PlanetHunters.Data.ExportDtos;

namespace PlanetHunter.ExportXmlAndJson
{
    public class Startup
    {
        static void Main(string[] args)
        {
            //ExportPlanets();

            var starSystem = Console.ReadLine();
            var planets = PlanetHunters.Data.Export.ExportPlanets.SendPlanets(starSystem);
            List<ExportPlanetDto> listPlanets = new List<ExportPlanetDto>();

        }

        private static void ExportPlanets()
        {
            var telescope = Console.ReadLine();
            var planets = PlanetHunters.Data.Export.ExportPlanets.SendPlanets(telescope);
            List<ExportPlanetDto> listPlanets = new List<ExportPlanetDto>();
            foreach (var p in planets)
            {
                ExportPlanetDto planetDto = new ExportPlanetDto()
                {
                    Name = p.Name,
                    Mass = p.Mass,
                    Orbiting = p.StarSystem.Name
                };
                listPlanets.Add(planetDto);
            }
            string json = JsonConvert.SerializeObject(listPlanets, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
