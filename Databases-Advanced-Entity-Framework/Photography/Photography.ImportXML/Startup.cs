using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Photography.Data;
using Photography.Data.DTO;
using Photography.Models;

namespace Photography.ImportXML
{
    public class Startup
    {
        static void Main(string[] args)
        {
            //ImportAccessories();

            using (var context = new PhotographyContext())
            {
                XDocument xmlDoc = XDocument.Load("../../Import/workshops.xml");
                XElement workshops = xmlDoc.Root;
                Random rnd = new Random();

                foreach (var a in workshops.Elements())
                {
                    decimal decPrice;

                    string workshopName = a.Attribute("name")?.Value;
                    string startDate = a.Attribute("start-date")?.Value;
                    string endDate = a.Attribute("end-date")?.Value;
                    string location = a.Attribute("location")?.Value;
                    var price = decimal.TryParse(a.Attribute("price")?.Value, out decPrice);
                    string trainerName = a.Element("trainer")?.Value;
                    var participants = a.Elements("participants");

                    WorkshopDto workshopDto = new WorkshopDto()
                    {
                        Name = workshopName,
                        StartDate = startDate,
                        EndDate = endDate,
                        Location = location,
                        Price = decPrice,
                        Trainer = trainerName,
                    };
                    List<ParticipantDto> participant = new List<ParticipantDto>();
                    foreach (var p in participants.Elements())
                    {
                       
                        string firstName = p.FirstAttribute.Value;
                        string lastName = p.LastAttribute.Value;
                        ParticipantDto par = new ParticipantDto()
                        {
                            FristName = firstName,
                            LastName = lastName
                        };
                        participant.Add(par);
                    }
                    workshopDto.Participants = participant;
                    var trainer = context.Photographers.FirstOrDefault(t => t.FirstName + " " + t.LastName == workshopDto.Trainer);
                    List<Photographer> listParticioant = new List<Photographer>();

                    foreach (var wp in workshopDto.Participants)
                    {
                        Photographer photographer =
                            context.Photographers.FirstOrDefault(
                                f => f.FirstName == wp.FristName && f.LastName == wp.LastName);
                        listParticioant.Add(photographer);
                    }
                    if (trainer != null)
                    {
                        Workshop workshop = new Workshop()
                        {
                            Name = workshopDto.Name,
                            //StartDate = DateTime.Parse(workshopDto.StartDate),
                            //EndDate = DateTime.Parse(workshopDto.EndDate),
                            Location = workshopDto.Location,
                            PrciePerParticipant = workshopDto.Price,
                            Trainer = trainer,
                            TrainerId = trainer.Id,
                            Participants = listParticioant
                        };
                        try
                        {
                            context.Workshops.Add(workshop);
                            context.SaveChanges();
                            Console.WriteLine($"Succesfully imported {workshop.Name}");
                        }
                        catch (DbEntityValidationException)
                        {
                            context.Workshops.Remove(workshop);
                            Console.WriteLine("Error. Invalid data provided");
                        }
                    }
                    
                }
                
            }
        }

        private static void ImportAccessories()
        {
            using (var context = new PhotographyContext())
            {
                XDocument xmlDoc = XDocument.Load("../../Import/accessories.xml");
                XElement accessories = xmlDoc.Root;
                Random rnd = new Random();

                foreach (var a in accessories.Elements())
                {
                    int id = rnd.Next(1, context.Photographers.Count());
                    var owner = context.Photographers.Find(id);
                    Accessory accessory = new Accessory()
                    {
                        Name = a.Attribute("name")?.Value,
                        Owner = owner
                    };
                    context.Accessories.Add(accessory);
                    Console.WriteLine($"Successfully imported {accessory.Name}");
                }
                context.SaveChanges();
            }
        }
    }
}
