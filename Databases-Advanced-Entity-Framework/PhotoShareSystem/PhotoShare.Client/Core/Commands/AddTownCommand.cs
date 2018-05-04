

using PhotoShare.Service;

namespace PhotoShare.Client.Core.Commands
{

    using System;
    using PhotoShare.Services;

    public class AddTownCommand
    {
        private TownService townService;

        public AddTownCommand(TownService townService)
        {
            this.townService = townService;
        }
        
        public string Execute(string[] data)
        {
            string townName = data[0];
            string country = data[1];

            if (this.townService.IsExisting(townName))
            {
                throw new ArgumentException($"Town {townName} was already added!");
            }
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            this.townService.Add(townName, country);

            return $"Town {townName} was added successfully!";
        }
    }
}
