using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using WeddingPlanner.Data;
using WeddingPlanner.Data.DTOs;
using WeddingPlanner.Data.Store;
using WeddingPlanner.Models;

namespace WeddingsPlanner.XMLImport
{
    public static class XmlImport
    {
        public static void ImportVenues()
        {
            XDocument xml = XDocument.Load("../../Import/venues.xml");
            XElement venues = xml.Root;
            List<VanueDto> listVenues = new List<VanueDto>();
            foreach (var v in venues.Elements())
            {
                VanueDto vanueDto = new VanueDto()
                {
                    Name = v.Attribute("name")?.Value,
                    Capacity = int.Parse(v.Element("capacity").Value),
                    Town = v.Element("town")?.Value
                };
                listVenues.Add(vanueDto);
            }
            VanueStore.AddVanues(listVenues);
        }

        public static void ImportPresents()
        {
            XDocument xml = XDocument.Load("../../Import/presents.xml");
            XElement presents = xml.Root;

            List<PresentDto> listPresents = new List<PresentDto>();

            foreach (var v in presents.Elements())
            {
                var invitation = PresentStore.IsInvitationExisting(v.Attribute("invitation-id").Value);
                if (invitation == false)
                {
                    Console.WriteLine("Error. Invalid data provided");
                }
                if (invitation)
                {
                    if (v.Attribute("type")?.Value == null)
                    {
                        Console.WriteLine("Error. Invalid data provided");
                    }
                    else if (v.Attribute("type")?.Value == "cash" && v.Attribute("amount")?.Value != null)
                    {
                        PresentDto p = new PresentDto()
                        {
                            InvitationId = int.Parse(v.Attribute("invitation-id").Value),
                            Amount = decimal.Parse(v.Attribute("amount").Value)
                        };
                        listPresents.Add(p);
                    }
                    else if (v.Attribute("type")?.Value == "gift" && v.Attribute("present-name")?.Value != null)
                    {
                        PresentDto p = new PresentDto()
                        {
                            InvitationId = int.Parse(v.Attribute("invitation-id").Value),
                            Name = v.Attribute("present-name")?.Value,
                            Size = v.Attribute("size")?.Value
                        };
                        listPresents.Add(p);
                    }
                    else
                    {
                        Console.WriteLine("Error. Invalid data provided");
                    }
                }
            }
            PresentStore.AddPresents(listPresents);
        }
        
    }
}
