using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SofUni.ViewModels;

namespace SofUni
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            // 17. Call stored procedure
            //GetProjectByName(context);

            // 18. Employees maximum salaries
            //GetMaxSalary(context);

        }

        private static void GetMaxSalary(SoftUniContext context)
        {
            var departments = context.Departments.Select(d => new
            {
                name = d.Name,
                maxSal = d.Employees.Max(e => e.Salary)
            });

            foreach (var d in departments.Where(d => d.maxSal < 30000 || d.maxSal > 70000))
            {
                Console.WriteLine($"{d.name} - {d.maxSal:F2}");
            }
        }

        private static void GetProjectByName(SoftUniContext context)
        {
            string[] name = Console.ReadLine().Split(' ');
            string firstName = name[0];
            string lastName = name[1];

            var result = context.Database.SqlQuery<ProjectViewModel>("EXEC dbo.usp_GetProjectsByEmployee {0}, {1}",
                firstName, lastName);
            foreach (var r in result)
            {
                Console.WriteLine($"{r.Name} {r.Description} {r.StartDate}");
            }
        }
    }
}
