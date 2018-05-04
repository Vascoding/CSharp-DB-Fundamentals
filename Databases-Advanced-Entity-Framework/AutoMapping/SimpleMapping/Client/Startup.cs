using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SimpleMapping.Models;

namespace SimpleMapping
{
    class Startup
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>());

            Employee employee = new Employee();
            employee.FirstName = "Pesho";
            employee.LastName = "Subev";
            employee.Salary = 10000;
            employee.Address = "ul.Petar Staikov 5";
            employee.BirthDay = new DateTime(1999, 5, 5);

            EmployeeDto dto = Mapper.Map<EmployeeDto>(employee);

            Console.WriteLine($"{dto.FirstName} {dto.LastName} - ${dto.Salary}");
        }
    }
}
