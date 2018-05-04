using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class ImportUsersCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);

            string filePath = inputArgs[0];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format(Constants.ErrorMessages.FileNotFound, filePath));
            }

            List<User> users;

            try
            {
                users = this.GetUsersFromXml(filePath);

            }
            catch (Exception)
            {
                
                throw new FormatException(Constants.ErrorMessages.InvalidXmlFormat);
            }

            this.AddUsers(users);

            return $"You have successfully imported {users.Count} users!";
        }

        private void AddUsers(List<User> users)
        {
            using (var context = new TeamBuilderContext())
            {
                foreach (var user in users)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
        }

        private List<User> GetUsersFromXml(string filePath)
        {
            XDocument xmlDoc = XDocument.Load(filePath);
            XElement users = xmlDoc.Root;
            List<User> list = new List<User>();
            foreach (var u in users.Elements())
            {
                int i;
                string userName = u.Element("username")?.Value;
                string password = u.Element("password")?.Value;
                string firstName = u.Element("first-name")?.Value;
                string lastName = u.Element("last-name")?.Value;
                int.TryParse(u.Element("age")?.Value, out i);
                string gender = u.Element("gender")?.Value;
                if (gender == "male")
                {
                    User user = new User()
                    {
                        Username = userName,
                        Password = password,
                        FirstName = firstName,
                        LastName = lastName,
                        Age = i,
                        Gender = Gender.Male
                    };
                    list.Add(user);
                }
                else
                {
                    User user = new User()
                    {
                        Username = userName,
                        Password = password,
                        FirstName = firstName,
                        LastName = lastName,
                        Age = i,
                        Gender = Gender.Female
                    };
                    list.Add(user);
                }
            }
            return list;
        }
    }
}
