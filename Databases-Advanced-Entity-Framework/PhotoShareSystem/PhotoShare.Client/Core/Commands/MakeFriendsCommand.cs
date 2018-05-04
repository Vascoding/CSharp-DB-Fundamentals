using PhotoShare.Models;
using PhotoShare.Service;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class MakeFriendsCommand
    {
        private UserService userService;

        public MakeFriendsCommand(UserService userService)
        {
            this.userService = userService;
        }
        // MakeFriends <username1> <username2>
        public string Execute(string[] data)
        {
            string firstUserName = data[0];
            string secondUserName = data[1];

            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (!this.userService.IsExisting(firstUserName))
            {
                throw new ArgumentException($"{firstUserName} not found!");
            }
            if (!this.userService.IsExisting(secondUserName))
            {
                throw new ArgumentException($"{secondUserName} not found!");
            }

            if (SecurityService.GetCurrentUser().Username != secondUserName)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            this.userService.MakeFriends(firstUserName, secondUserName);

            return $"Friend {secondUserName} added to {firstUserName}";
        }
    }
}
