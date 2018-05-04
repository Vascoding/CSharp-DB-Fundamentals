using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeddingPlanner.Data;
using WeddingPlanner.Models;

namespace WeddingsPlanner.ExportJson
{
    public class Startup
    {
        static void Main(string[] args)
        {
            //OrderedAgencies();
            //ExportGuests();
        }

        private static void ExportGuests()
        {
            using (var context = new WeddingsPlannerContext())
            {
                var weddings = context.Weddings
                    .OrderByDescending(w => w.Invitations.Count)
                    .ThenBy(w => w.Invitations.Select(i => i.Attending).Count())
                    .Select(w => new
                    {
                        bride = w.Bride.FirstName + " " + w.Bride.MiddleNameInitial + " " + w.Bride.LastName,
                        bridegroom = w.Bridegroom.FirstName + " " + w.Bridegroom.MiddleNameInitial + " " + w.Bridegroom.LastName,
                        agency = new
                        {
                            name = w.Agency.Name,
                            town = w.Agency.Town
                        },
                        invitedGuests = w.Invitations.Count,
                        brideGuests = w.Invitations.Where(i => i.Family == Family.Bride).Count(),
                        bridegroomGuests = w.Invitations.Where(i => i.Family == Family.BrideGroom).Count(),
                        attendingGuests = w.Invitations.Where(i => i.Attending == true).Count(),
                        guests = w.Invitations.Where(i => i.Attending).Select(i => i.Guest.FirstName + " " + i.Guest.MiddleNameInitial + " " + i.Guest.LastName)
                    }).ToList();
                string json = JsonConvert.SerializeObject(weddings, Formatting.Indented);
                //File.WriteAllText(@"../../Export/guests.json", json);
                Console.WriteLine(json);
            }
        }

        private static void OrderedAgencies()
        {
            using (var context = new WeddingsPlannerContext())
            {
                var agencies = context.Agencies.OrderByDescending(e => e.EmployeesCount).ThenBy(a => a.Name).Select(a => new
                {
                    Name = a.Name,
                    EmployeesCount = a.EmployeesCount,
                    Town = a.Town
                }).ToList();

                string json = JsonConvert.SerializeObject(agencies, Formatting.Indented);
                File.WriteAllText(@"../../Export/agencies-ordered.json", json);
            }
        }
    }
}
