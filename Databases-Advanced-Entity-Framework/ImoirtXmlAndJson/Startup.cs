using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using PlanetHunters.Data;
using PlanetHunters.Data.Dtos;
using PlanetHunters.Data.Import;

namespace ImportJSON
{
    public class Startup
    {
        static void Main(string[] args)
        {
            // Importing astronomers from JSON format.
            //ImportAstronamers();

            // Importing telescopes from JSON format.
            //ImportTelescopes();

            // Importing planets from JSON format.
            //ImportPlanets();

            // Importing starts from XML format.
            //ImportStars();

            // Importing discoveries from XML format

            XDocument xmlDoc = XDocument.Load("../../Import/discoveries.xml");
            var discoveries = xmlDoc.Root.Elements();
            List<StarDto> discoverisesDtos = new List<StarDto>();

            foreach (var d in discoveries)
            {
                DiscoveryDto discovery = new DiscoveryDto()
                {
                    DateMade = DateTime.Parse(d.Attribute("DateMade")?.Value),
                    Telescope = d.Attribute("Telescope")?.Value,
                };
                foreach (var s in d.Elements("Stars"))
                {
                    int temp;
                    int.TryParse(s.Attribute("Temperature").Value, out temp);
                    XMLStarDto starDto = new XMLStarDto()
                    {
                        Name = s.Element("Star")?.Value,
                        Temperature = temp

                    };
                    discovery.Stars.Add(starDto);
                }
                foreach (var p in d.Elements("Planets"))
                {
                    PlanetDto planetDto = new PlanetDto()
                    {
                        Name = p.Element("Planet")?.Value
                    };
                    discovery.Planets.Add(planetDto);
                }
                if (d.Element("Pioneers").HasElements)
                {
                    foreach (var a in d.Elements("Pioneers"))
                    {
                        var splitName = a.Element("Astronomer")
                            .Value.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        AstronomerDto astronomerDto = new AstronomerDto()
                        {
                            FirstName = splitName[0],
                            LastName = splitName[1]
                        };
                        discovery.Pioneers.Add(astronomerDto);
                    }
                }

                if (d.Element("Observers").HasElements)
                {
                    foreach (var a in d.Elements("Observer"))
                    {
                        var splitName = a.Element("Astronomer")
                            .Value.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        AstronomerDto astronomerDto = new AstronomerDto()
                        {
                            FirstName = splitName[0],
                            LastName = splitName[1]
                        };
                        discovery.Observers.Add(astronomerDto);
                    }
                }

            }
        }

        private static void ImportStars()
        {
            XDocument xmlDoc = XDocument.Load("../../Import/stars.xml");
            var starsElements = xmlDoc.Root.Elements();
            List<StarDto> stars = new List<StarDto>();
            foreach (var s in starsElements)
            {
                StarDto star = new StarDto()
                {
                    Name = s.Element("Name")?.Value,
                    Temperature = int.Parse(s.Element("Temperature").Value),
                    StarSystem = s.Element("StarSystem")?.Value
                };
                stars.Add(star);
            }
            PlanetHunters.Data.Import.ImportStars.AddStars(stars);
        }

        private static void ImportPlanets()
        {
            string json = File.ReadAllText("../../Import/planets.json");
            List<PlanetDto> planets = JsonConvert.DeserializeObject<List<PlanetDto>>(json);
            PlanetHunters.Data.Import.ImportPlanets.AddPlanets(planets);
        }

        private static void ImportTelescopes()
        {
            string json = File.ReadAllText("../../Import/telescopes.json");
            List<TelescopeDto> telescopes = JsonConvert.DeserializeObject<List<TelescopeDto>>(json);
            PlanetHunters.Data.Import.ImportTelescopes.AddTelescopes(telescopes);
        }

        private static void ImportAstronamers()
        {
            string json = File.ReadAllText("../../Import/astronomers.json");
            List<AstronomerDto> astronomers = JsonConvert.DeserializeObject<List<AstronomerDto>>(json);
            ImportAstronomers.AddAstronommers(astronomers);
        }
    }
}
