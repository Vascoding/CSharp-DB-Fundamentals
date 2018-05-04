using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using GringottsDatabase.Models;

namespace GringottsDatabase
{
    public class Startup
    {
        static void Main(string[] args)
        {
            //WizardTable();
            //CreateUser();
            //GetUserByEmailProvider();
            //RemoveInactiveUsers();
        }

        private static void RemoveInactiveUsers()
        {
            var inputDate = DateTime.Parse(Console.ReadLine());
            GringottsContext context = new GringottsContext();
            var user = context.User.Where(u => u.LastTimeLoggedIn <= inputDate).ToList();
            int count = 0;
            foreach (var u in user)
            {
                u.IsDeleted = true;
                count++;
                //context.SaveChanges(); -- cannot apply changes becouse inserted Usernames and passwords not match Model's annotations
            }

            if (count > 0)
            {
                Console.WriteLine($"{count} users have been deleted");
            }
            else
            {
                Console.WriteLine("No users have been deleted");
            }

            var market = context.User.Where(u => u.IsDeleted).ToList();
            foreach (var mark in market)
            {
                context.User.Remove(mark);
                context.SaveChanges();
            }
        }

        private static void GetUserByEmailProvider()
        {
            GringottsContext context = new GringottsContext();

            string input = Console.ReadLine();

            var user = context.User.Where(e => e.Email.Contains(input)).ToList();
            foreach (var u in user)
            {
                Console.WriteLine($"{u.Username} {u.Email}");
            }
        }

        private static void CreateUser()
        {
            User newUser = new User()
            {
                Username = "Dаncho",
                Password = "ab@A9az",
                Email = "dancho@abv.bg",
                RegisteredOn = new DateTime(2016, 10, 20),
                LastTimeLoggedIn = new DateTime(2016, 12, 12),
                Age = 50
            };

            GringottsContext context = new GringottsContext();
            context.User.Add(newUser);
            context.SaveChanges();
        }
         
        private static void WizardTable()
        {
            WizardDeposits createWizz = new WizardDeposits()
            {
                Id = 1,
                FirstName = "Stoian",
                LastName = "Petrov",
                Age = 150,
                MagicWandCreator = "Antioch Paverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 2000.24m,
                DepositCharge = 0.2m,
                IsDepositExpired = false
            };

            GringottsContext context = new GringottsContext();
            context.WizardDeposits.Add(createWizz);
            context.SaveChanges();
        }
    }
}
