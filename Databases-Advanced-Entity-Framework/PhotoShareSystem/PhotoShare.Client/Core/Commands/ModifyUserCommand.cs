









namespace PhotoShare.Client.Core.Commands
{
    using Services;
    using Models;
    using System;

    public class ModifyUserCommand
    {
        private UserService userService;

        private TownService townService;

        public ModifyUserCommand(UserService userService, TownService townService)
        {
            this.userService = userService;
            this.townService = townService;
        }
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            string userName = data[0];
            string property = data[1];
            string value = data[2];

            User user = this.userService.GetUser(userName);

            if (property == "Password")
            {
                user.Password = value;
            }
            else if (property == "BornTown")
            {
                Town town = this.townService.GetTown(value);
                if (town == null)
                {
                    throw new ArgumentException();
                }

                user.BornTown = town;
            }
            else if (property == "CurrentTown")
            {
                Town town = this.townService.GetTown(value);
                if (town == null)
                {
                    throw new ArgumentException();
                }

                user.CurrentTown = town;
            }
            else
            {
                throw new ArgumentException($"Property {property} not supported!");
            }

            this.userService.ModifyUser(user);
            return $"User {userName} {property} is {value}.";
        }
    }
}
