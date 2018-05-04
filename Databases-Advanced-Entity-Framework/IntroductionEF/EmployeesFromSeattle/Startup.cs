using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesFromSeattle
{
    class Startup
    {
        static void Main(string[] args)
        {
            SofUniContext context = new SofUniContext();
            using (context)
            {
                //EmployeesFromSeattle(context);
                //AddNewAddress(context);
                //EmployeesByPeriod(context);
                //AddressByTown(context);
                //EmployeeWithId(context);
                //DepWhithMoreThan5Emp(context);
                //FindLatest10Projects(context);
                //IncreaseSalary(context);
                //EmployeesByFirstName(context);
                //RemoveProject(context);
                //DeleteAddress(context);
            }

        }

        private static void DeleteAddress(SofUniContext context)
        {
            var input = Console.ReadLine();

            var address = context.Addresses.Where(a => a.Town.Name == input).ToList();
            var employee = context.Employees.Where(e => e.Address.Town.Name == input).ToList();
            foreach (var emp in employee)
            {
                emp.AddressID = null;
            }
            var count = 0;
            foreach (var add in address)
            {
                context.Addresses.Remove(add);
                count++;
            }
            if (count == 1)
            {
                Console.WriteLine($"{count} in {input} was deleted");
            }
            else if (count > 1)
            {
                Console.WriteLine($"{count} in {input} were deleted");
            }
            else
            {
                Console.WriteLine("No addresses where found");
            }
        }

        private static void RemoveProject(SofUniContext context)
        {
            var project = context.Projects.Find(2);
            var employees = project.Employees.ToList();

            foreach (var emp in employees)
            {
                emp.Projects.Remove(project);
            }

            context.Projects.Remove(project);
            context.SaveChanges();
            var proj = context.Projects.Take(10).ToList();
            foreach (var p in proj)
            {
                Console.WriteLine(p.Name);
            }
        }

        private static void EmployeesByFirstName(SofUniContext context)
        {
            var employees = context.Employees.Where(e => e.FirstName.Substring(0, 2).ToLower() == "sa").ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary})");
            }
        }

        private static void IncreaseSalary(SofUniContext context)
        {
            var employees = context.Employees.Where(e => e.Department.Name == "Engineering"
                                                                     || e.Department.Name == "Tool Design"
                                                                     || e.Department.Name == "Information Services"
                                                                     || e.Department.Name == "Marketing").ToList();

            foreach (var emp in employees)
            {
                emp.Salary *= 1.12m;
                Console.WriteLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:f6})");
            }

        }

        private static void FindLatest10Projects(SofUniContext context)
        {
            var projects = context.Projects.OrderByDescending(p => p.StartDate).Take(10).ToList();

            foreach (var proj in projects.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{proj.Name} {proj.Description} {proj.StartDate:M/d/yyyy h:mm:ss tt} {proj.EndDate:M/d/yyyy h:mm:ss tt}");
            }
        }

        private static void DepWhithMoreThan5Emp(SofUniContext context)
        {
            var departments =
                            context.Departments.Where(d => d.Employees.Count > 5).OrderBy(e => e.Employees.Count).ToList();

            foreach (var dep in departments)
            {
                Console.WriteLine($"{dep.Name} {dep.Manager.FirstName}");
                foreach (var emp in dep.Employees)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
                }
            }
        }

        private static void EmployeeWithId(SofUniContext context)
        {
            var employee = context.Employees.Where(e => e.EmployeeID == 147).ToList();

            foreach (var emp in employee)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
                foreach (var proj in emp.Projects.OrderBy(p => p.Name))
                {
                    Console.WriteLine($"{proj.Name}");
                }
            }
        }

        private static void AddressByTown(SofUniContext context)
        {
            var address =
                            context.Addresses.OrderByDescending(a => a.Employees.Count).ThenBy(t => t.Town.Name).Take(10).ToList();
            foreach (var add in address)
            {
                Console.WriteLine($"{add.AddressText}, {add.Town.Name} - {add.Employees.Count} employees");
            }
        }

        private static void EmployeesByPeriod(SofUniContext context)
        {
            var employyes = context.Employees
                            .Where(e => e.Projects.Count(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003) > 0)
                            .Take(30);
            foreach (var e in employyes)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.Manager.FirstName}");
                foreach (var p in e.Projects)
                {
                    Console.WriteLine($"--{p.Name} {p.StartDate:M/d/yyyy h:mm:ss tt}AM {p.EndDate:M/d/yyyy h:mm:ss tt}");
                }
            }
        }

        private static void AddNewAddress(SofUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownID = 4
            };

            context.Addresses.Add(address);
            context.SaveChanges();

            Employee emp = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            emp.Address = address;
            context.SaveChanges();

            var addresses = context.Employees.OrderByDescending(e => e.AddressID).Take(10);
            foreach (var add in addresses)
            {
                Console.WriteLine($"{add.Address.AddressText}");
            }
        }

        private static void EmployeesFromSeattle(SofUniContext context)
        {
            var emp = context.Employees.Where(e => e.Department.Name == "Research and Development")
                            .OrderBy(e => e.Salary)
                            .ThenByDescending(e => e.FirstName).ToList();

            foreach (var e in emp)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}");
            }
        }

    }
}
