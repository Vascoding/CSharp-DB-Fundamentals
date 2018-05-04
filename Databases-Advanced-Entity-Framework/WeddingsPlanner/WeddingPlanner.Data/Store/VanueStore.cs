using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeddingPlanner.Data.DTOs;
using WeddingPlanner.Models;

namespace WeddingPlanner.Data.Store
{
    public static class VanueStore
    {
        public static void AddVanues(List<VanueDto> listVenues)
        {
            using (var context = new WeddingsPlannerContext())
            {
                foreach (var v in listVenues)
                {
                    Venue venue = new Venue()
                    {
                        Name = v.Name,
                        Capacity = v.Capacity,
                        Town = v.Town
                    };
                    context.Venues.Add(venue);
                    Console.WriteLine($"Successfully imported {venue.Name}");
                }
                context.SaveChanges();
                Random rnd = new Random();
                foreach (var w in context.Weddings)
                {
                    int vanueId = rnd.Next(1, context.Venues.Count());
                    int vanueId2 = rnd.Next(1, context.Venues.Count());
                    w.Venues.Add(context.Venues.Find(vanueId));
                    w.Venues.Add(context.Venues.Find(vanueId2));
                }
                context.SaveChanges();
            }
        }
    }
}
