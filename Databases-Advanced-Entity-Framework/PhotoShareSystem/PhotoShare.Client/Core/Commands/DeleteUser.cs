using PhotoShare.Service;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    public class DeleteUser
    {
        private UserService userService;

        public DeleteUser(UserService userService)
        {
            this.userService = userService;
        }

        public string Execute(string[] data)
        {
            string userName = data[0];

            if (!this.userService.IsExisting(userName))
            {
                throw new ArgumentException($"User {userName} not found!");
            }

            if (!SecurityService.IsAuthenticated() || SecurityService.GetCurrentUser().Username != userName)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            if ((SecurityService.IsAuthenticated() || SecurityService.GetCurrentUser().Username == userName) && SecurityService.GetCurrentUser().IsDeleted == true)
            {
                throw new InvalidOperationException("user is already removed");
            }

            this.userService.Remove(userName);
            return $"User {userName} was deleted successfully!";
        }
    }
}
