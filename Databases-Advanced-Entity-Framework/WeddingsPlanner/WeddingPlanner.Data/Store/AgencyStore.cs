using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingPlanner.Models;
using WeddingsPlanner.JSONImport.DTOs;

namespace WeddingPlanner.Data.Store
{
    public static class AgencyStore
    {
        public static void AddAgencies(IEnumerable<AgencyDto> agencies)
        {
            using (var context = new WeddingsPlannerContext())
            {
                foreach (var agencyDto in agencies)
                {
                    Agency agency = new Agency()
                    {
                        Name = agencyDto.Name,
                        EmployeesCount = agencyDto.EmployeesCount,
                        Town = agencyDto.Town
                    };
                    Console.WriteLine($"Successfully imported {agency.Name}");
                    context.Agencies.Add(agency);
                }
                context.SaveChanges();
            }
        }
    }
}
