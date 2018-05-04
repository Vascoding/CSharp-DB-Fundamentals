using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using KTB.Data;
using KTB.Data.Dtos;
using KTB.Models;

namespace KTB.Import
{
    public static class ImportCustomer
    {
        public static void Import()
        {
            using (var context = new KTBContext())
            {
                XDocument xmlDoc = XDocument.Load("../../Import/users.xml");
                XElement users = xmlDoc.Root;

                foreach (var u in users.Elements())
                {
                    CustomerDto customerDto = new CustomerDto()
                    {
                        Username = u.Element("username")?.Value,
                        Password = u.Element("password")?.Value,
                        FirstName = u.Element("first-name")?.Value,
                        LastName = u.Element("last-name")?.Value,
                        Age = int.Parse(u.Element("age").Value),
                        Gender = u.Element("gender")?.Value
                    };

                    if (customerDto.Gender == "male")
                    {
                        Customer customer = new Customer()
                        {
                            Username = customerDto.Username,
                            Password = customerDto.Password,
                            FirstName = customerDto.FirstName,
                            LastName = customerDto.LastName,
                            Age = customerDto.Age,
                            Gender = Gender.Male
                        };
                        context.Customers.Add(customer);
                        Console.WriteLine($"Successfully imported {customer.Username}");
                    }
                    else
                    {
                        Customer customer = new Customer()
                        {
                            Username = customerDto.Username,
                            Password = customerDto.Password,
                            FirstName = customerDto.FirstName,
                            LastName = customerDto.LastName,
                            Age = customerDto.Age,
                            Gender = Gender.Female
                        };
                        context.Customers.Add(customer);
                        Console.WriteLine($"Successfully imported {customer.Username}");
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
