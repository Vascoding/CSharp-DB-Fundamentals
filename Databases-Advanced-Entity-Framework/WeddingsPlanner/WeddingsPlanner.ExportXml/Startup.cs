using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeddingPlanner.Data;
using WeddingPlanner.Models;

namespace WeddingsPlanner.ExportXml
{
    public class Startup
    {
        static void Main(string[] args)
        {
            //SofiaVenues();

            using (var context = new WeddingsPlannerContext())
            {
                var towns = context.Agencies
                    .GroupBy(a => a.Town, a => a, (town, agencies) => new
                    {
                        Town = town,
                        Agencies = agencies.Where(a => a.OrganizedWeddings.Count() > 1)
                    })
                    .Where(t => t.Town.Length > 5);

                var xml = new XElement("towns");
                foreach (var town in towns)
                {
                    var townNode = new XElement("town");
                    townNode.Add(new XAttribute("name", town.Town));
                    var agenciesNode = new XElement("agencies");
                    foreach (var agency in town.Agencies)
                    {
                        var agencyNode = new XElement("agency");
                        agencyNode.Add(new XAttribute("name", agency.Name));
                        agencyNode.Add(new XAttribute("profit", CalculateProfit(agency.OrganizedWeddings)));
                        foreach (var wedding in agency.OrganizedWeddings)
                        {
                            var weddingNode = new XElement("wedding");
                            weddingNode.Add(new XAttribute("cash", CalculateWeddingCash(wedding.Invitations)));
                            weddingNode.Add(new XAttribute("presents", GetPresentsCount(wedding.Invitations)));
                            weddingNode.Add(new XElement("bride", wedding.Bride.FirstName));
                            weddingNode.Add(new XElement("bridegroom", wedding.Bridegroom.FirstName));
                            var guestsNode = new XElement("guests");
                            foreach (var guest in wedding.Invitations)
                            {
                                var guestNode = new XElement("guest", guest);
                                guestNode.Add(new XAttribute("family", guest.Family));
                                guestsNode.Add(guestNode);
                            }
                            weddingNode.Add(guestsNode);
                            agencyNode.Add(weddingNode);
                        }
                        agenciesNode.Add(agencyNode);
                    }
                    townNode.Add(agenciesNode);
                    xml.Add(townNode);
                }
                xml.Save("../../Export/agencies-by-location.xml");
            }
        }
        private static decimal CalculateProfit(ICollection<Wedding> organizedWeddings)
        {
            return organizedWeddings
                .Sum(w => w.Invitations
                .Where(i => (i.Present as Cash) != null)
                    .Sum(i => (i.Present as Cash).Amount)
                ) * 0.2m;
        }

        private static int GetPresentsCount(ICollection<Invitation> invitations)
        {
            return invitations.Where(i => (i.Present as Gift) != null)
                .Count();
        }

        private static decimal CalculateWeddingCash(ICollection<Invitation> invitations)
        {
            return invitations.Where(i => (i.Present as Cash) != null)
                .Sum(i => (i.Present as Cash).Amount);
        }

        private static void SofiaVenues()
        {
            using (var context = new WeddingsPlannerContext())
            {
                var venues =
                    context.Venues.Where(v => v.Town == "Sofia" && v.Weddings.Count > 2)
                        .OrderBy(v => v.Capacity)
                        .Select(v => new
                        {
                            Name = v.Name,
                            Capacity = v.Capacity,
                            Town = v.Town,
                            WeddingCount = v.Weddings.Count
                        }).ToList();

                XElement xmlDoc = new XElement("venues");

                foreach (var v in venues)
                {
                    xmlDoc.SetAttributeValue("town", v.Town);
                    XElement venueElement = new XElement("venue");
                    venueElement.SetAttributeValue("name", v.Name);
                    venueElement.SetAttributeValue("capacity", v.Capacity);
                    XElement countElement = new XElement("weddings-count");
                    countElement.Value = v.WeddingCount.ToString();

                    venueElement.Add(countElement);
                    xmlDoc.Add(venueElement);
                }
                Console.WriteLine(xmlDoc);
                //xmlDoc.Save("../../Export/sofia-venues.xml");
            }
        }
    }
}
