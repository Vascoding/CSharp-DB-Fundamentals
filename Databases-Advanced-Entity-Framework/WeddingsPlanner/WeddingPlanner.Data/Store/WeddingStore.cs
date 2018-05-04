using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingPlanner.Data.DTOs;
using WeddingPlanner.Models;

namespace WeddingPlanner.Data.Store
{
    public static class WeddingStore
    {
        public static void AddWeddings(IEnumerable<WeddingDto> weddings)
        {
            using (var context = new WeddingsPlannerContext())
            {
                foreach (var weddingDto in weddings)
                {
                    if (weddingDto.Bride == null || weddingDto.Bridegroom == null || weddingDto.Date == null ||
                        weddingDto.Agency == null)
                    {
                        Console.WriteLine("Error. Invalid data provided");
                    }

                    Person bride = context.People.FirstOrDefault(b => b.FirstName + " " + b.MiddleNameInitial + " " + b.LastName == weddingDto.Bride);
                    Person brideGroom = context.People.FirstOrDefault(b => b.FirstName + " " + b.MiddleNameInitial + " " + b.LastName == weddingDto.Bridegroom);
                    Agency agency = context.Agencies.FirstOrDefault(a => a.Name == weddingDto.Agency);

                    Wedding wedding = new Wedding()
                    {
                        Bride = bride,
                        Bridegroom = brideGroom,
                        Date = weddingDto.Date,
                        Agency = agency,
                    };
                    if (weddingDto.Guests != null)
                    {
                        foreach (var w in weddingDto.Guests)
                        {
                            var guest = context.People.FirstOrDefault(g =>g.FirstName + " " + g.MiddleNameInitial + " " + g.LastName == w.Name);
                            if (guest != null)
                            {
                                wedding.Invitations.Add(new Invitation()
                                {
                                    Guest = guest,
                                    Attending = w.RSVP,
                                    Family = w.Family
                                });
                            }
                        }
                    }
                    

                    try
                    {
                        context.Weddings.Add(wedding);
                        context.SaveChanges();
                        Console.WriteLine($"Succesfully imported wedding of ");
                    }
                    catch (DbEntityValidationException)
                    {
                        context.Weddings.Remove(wedding);
                        Console.WriteLine("Error. Invalid data provided");
                    }
                }
            }
        }
    }
}
