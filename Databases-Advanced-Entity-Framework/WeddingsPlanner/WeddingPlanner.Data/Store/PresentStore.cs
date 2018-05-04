using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingPlanner.Data.DTOs;
using WeddingPlanner.Models;

namespace WeddingPlanner.Data.Store
{
    public static class PresentStore
    {
        public static void AddPresents(List<PresentDto> listPresents)
        {

            using (var context = new WeddingsPlannerContext())
            {

                foreach (var p in listPresents)
                {
                    Invitation invitation = context.Invitations.FirstOrDefault(i => i.Id == p.InvitationId);


                    Present present = new Present()
                    {
                        Invitation = invitation,
                        InvitationId = invitation.Id
                    };
                    
                    Console.WriteLine("Succesfully imported gift ");
                    if (p.Type == "gift")
                    {
                        if (p.Size == "NotSpecified")
                        {
                            Gift gift = new Gift()
                            {
                                Name = p.Name,
                                Size = Size.NotSpecified
                            };
                            context.Invitations.Attach(invitation);
                            invitation.Present = gift;
                            context.SaveChanges();
                        }
                        else if (p.Size == "Small")
                        {
                            Gift gift = new Gift()
                            {
                                Name = p.Name,
                                Size = Size.Small
                            };
                            context.Invitations.Attach(invitation);
                            invitation.Present = gift;
                            context.SaveChanges();
                        }

                        else if (p.Size == "Medium")
                        {
                            Gift gift = new Gift()
                            {
                                Name = p.Name,
                                Size = Size.Medium
                            };
                            context.Invitations.Attach(invitation);
                            invitation.Present = gift;
                            context.SaveChanges();
                        }

                        else if (p.Size == "Large")
                        {
                            Gift gift = new Gift()
                            {
                                Name = p.Name,
                                Size = Size.Large
                            };
                            context.Invitations.Attach(invitation);
                            invitation.Present = gift;
                            context.SaveChanges();
                        }

                    }
                    if (p.Type == "cash")
                    {
                        Cash cash = new Cash()
                        {
                            Amount = p.Amount
                        };
                        context.Invitations.Attach(invitation);
                        invitation.Present = cash;
                        context.SaveChanges();
                    }
                }

                context.SaveChanges();
            }
        }

        public static bool IsInvitationExisting(string value)
        {
            int id = int.Parse(value);
            using (var context = new WeddingsPlannerContext())
            {
                Invitation invitation = context.Invitations.FirstOrDefault(i => i.Id == id);
                if (invitation == null)
                {
                    return false;
                }
            }
            return true;
        }

        public static void GetPresent()
        {
            using (var context = new WeddingsPlannerContext())
            {
                var presents = context.Presents.Select(p => p.Invitation.Present).ToList();
                foreach (var p in presents)
                {

                }
            }
        }
    }
}
