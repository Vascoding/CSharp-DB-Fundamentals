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
    public static class PersonStore
    {
        public static void AddPeople(IEnumerable<PersonDto> people)
        {
            using (var context = new WeddingsPlannerContext())
            {
                foreach (var personDto in people)
                {
                    if (personDto.FirstName == null || personDto.LastName == null ||
                        personDto.MiddleInitial == null || personDto.MiddleInitial.Length != 1)
                    {
                        Console.WriteLine("Error. Invalid data provided");
                        continue;
                    }
                    var person = new Person()
                    {
                        FirstName = personDto.FirstName,
                        LastName = personDto.LastName,
                        MiddleNameInitial = personDto.MiddleInitial[0].ToString(),
                        Gender = personDto.Gender,
                        BirthDate = personDto.Birthday,
                        Phone = personDto.Phone,
                        Email = personDto.Email
                    };
                    try
                    {
                        context.People.Add(person);
                        context.SaveChanges();
                        Console.WriteLine($"Succesfully imported {person.FullName}");
                    }
                    catch (DbEntityValidationException)
                    {
                        context.People.Remove(person);
                        Console.WriteLine("Error. Invalid data provided");
                    }
                }
                
            }
        }
    }
}
