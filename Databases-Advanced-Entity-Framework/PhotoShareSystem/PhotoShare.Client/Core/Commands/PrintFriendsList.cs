using PhotoShare.Models;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class PrintFriendsListCommand
    {
        private UserService userService;

        public PrintFriendsListCommand(UserService userService)
        {
            this.userService = userService;
        }
        // PrintFriendsList <username>
        public string Execute(string[] data)
        {
            string userName = data[0];

            if (!this.userService.IsExisting(userName))
            {
                throw new ArgumentException($"User {userName} not found!");
            }

            return this.userService.ListFriends(userName);
        }
    }
}
