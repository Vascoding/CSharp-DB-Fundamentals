﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedMapping.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Projection
{
    class Startup
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                .ForMember(emp => emp.ManagerLastName, config => config.MapFrom(e => e.Manager.LastName));
                
            });
            using (var context = new ProjectionContext())
            {
                var employees =
                    context.Employees.Where(e => e.BirthDay.Year < 1990)
                        .OrderByDescending(e => e.Salary)
                        .ProjectTo<EmployeeDto>();
                foreach (var e in employees)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private static List<Employee> CreateEmployees()
        {
            var managers = new List<Employee>();
            Employee manager = new Employee();
            manager.FirstName = "Kircho";
            manager.LastName = "Kirilov";
            manager.Address = "ul. Tintiava 10";
            manager.BirthDay = new DateTime(1985, 1, 2);
            manager.IsOnHoliday = false;
            manager.Salary = 15000;

            Employee emp2 = new Employee();
            emp2.FirstName = "Petur";
            emp2.LastName = "Staikov";
            emp2.Address = "ul. Detelina 10";
            emp2.BirthDay = new DateTime(1985, 1, 2);
            emp2.IsOnHoliday = false;
            emp2.Salary = 2000;
            emp2.Manager = manager;

            Employee emp3 = new Employee();
            emp3.FirstName = "Gosho";
            emp3.LastName = "Petrov";
            emp3.Address = "ul. Veselina 10";
            emp3.BirthDay = new DateTime(1985, 1, 2);
            emp3.IsOnHoliday = false;
            emp3.Salary = 51000;
            emp3.Manager = manager;


            Employee emp4 = new Employee();
            emp4.FirstName = "Stoian";
            emp4.LastName = "Grigorov";
            emp4.Address = "ul. Tsar Boris 3";
            emp4.BirthDay = new DateTime(1985, 1, 2);
            emp4.IsOnHoliday = false;
            emp4.Salary = 4000;
            emp4.Manager = manager;

            manager.Subordinates.Add(emp2);
            manager.Subordinates.Add(emp3);
            manager.Subordinates.Add(emp4);
            managers.Add(manager);
            return managers;
        }
    }
}
