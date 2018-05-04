using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Employees
{
    class Startup
    {
        static void Main(string[] args)
        {
            EmployeeContext context = new EmployeeContext();
            Stopwatch stopwatch = new Stopwatch();
            long timePassed = 0L;
            int testCount = 10; // Amount of tests to perform
            for (int i = 0; i < testCount; i++)
            {
                // Clear all query cache
                context.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");
                stopwatch.Start();

                OptimizeQuery(context);

                stopwatch.Stop();
                timePassed += stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

            TimeSpan averageTimePassed = TimeSpan.FromMilliseconds(timePassed / (double)testCount);
            Console.WriteLine(averageTimePassed);
            
        }

        private static void QueryWithEagerLoading(EmployeeContext context)
        {
            //5. Lazy vs Eager (Performance case #1)
            //var employees = context.Employees.Include("Department").Include("Address").ToList();
            //foreach (var e in employees)
            //{
            //    string result = $"{e.FirstName} - {e.Department.Name} - {e.Address.AddressText}";
            //}


            //6. Lazy vs Eager (Using Select)
            //var employees = context.Employees.Include("Department").Include("Address").Select(e => new
            //{
            //    firstName = e.FirstName,
            //    departmentName = e.Department.Name,
            //    addressText = e.Address.AddressText
            //}).ToList();
            //foreach (var e in employees)
            //{
            //    string result = $"{e.firstName} - {e.departmentName} - {e.addressText}";
            //}


            //7. Lazy vs Eager (Performance case #2)
            //var employees = context.Employees.Include("Department").Include("Address").Where(e => e.Salary < 3000).ToList();
            //foreach (var e in employees)
            //{
            //    string result = $"{e.FirstName} - {e.Department.Name} - {e.Address.AddressText}";
            //}


            //8. Lazy vs Eager (Performance case #3)
            //var employees = context.Employees.Include("Department").Where(e => e.EmployeesProjects.Count == 1).ToList();
            //foreach (var e in employees)
            //{
            //    string result = $"{e.FirstName} - {e.Department.Name}";
            //}

            //9. Order by and ToList
            //var employees = context.Employees.OrderBy(e => e.Department.Name).ThenBy(e => e.FirstName).ToList();
            //foreach (var e in employees)
            //{
            //    string result = $"{e.FirstName} - {e.Department.Name}";
            //}
        }

        private static void QueryWithLazyLoading(EmployeeContext context)
        {
            //5. Lazy vs Eager (Performance case #1)
            //var employees = context.Employees.ToList();
            //foreach (var e in employees)
            //{
            //    string result = $"{e.FirstName} - {e.Department.Name} - {e.Address.AddressText}";
            //}


            //6. Lazy vs Eager (Using Select)
            //var employees = context.Employees.Select(e => new
            //{
            //    firstName = e.FirstName,
            //    departmentName = e.Department.Name,
            //    addressText = e.Address.AddressText
            //}).ToList();
            //foreach (var e in employees)
            //{
            //    string result = $"{e.firstName} - {e.departmentName} - {e.addressText}";
            //}


            //7. Lazy vs Eager (Performance case #2)
            //var employees = context.Employees.Where(e => e.Salary < 3000).ToList();
            //foreach (var e in employees)
            //{
            //    string result = $"{e.FirstName} - {e.Department.Name} - {e.Address.AddressText}";
            //}


            //8. Lazy vs Eager (Performance case #3)
            //var employees = context.Employees.Where(e => e.EmployeesProjects.Count == 1).ToList();
            //foreach (var e in employees)
            //{
            //    string result = $"{e.FirstName} - {e.Department.Name}";
            //}


            //9. Order by and ToList
            //var employees = context.Employees.ToList().OrderBy(e => e.Department.Name).ThenBy(e => e.FirstName);
            //foreach (var e in employees)
            //{
            //    string result = $"{e.FirstName} - {e.Department.Name}";
            //}
        }

        private static void OptimizeQuery(EmployeeContext context)
        {
            var employees = context.Employees
                .Where(e => e.Subordinates.Any(s => s.Address.Town.Name.StartsWith("B")))
                .Distinct()
                .ToList();

            foreach (Employee e in employees)
            {
                string result = $"{e.FirstName}";
            }

        }
    }
}
