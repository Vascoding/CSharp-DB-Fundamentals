namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Models;
    using Service;

    public class LogoutCommand
    {
        public string Execute(string[] data)
        {
            User user = SecurityService.GetCurrentUser();

            if (user == null)
            {
                throw new InvalidOperationException("You should log in first in order to logout.");
            }

            SecurityService.Logout();

            return $"User {user.Username} successfully logged out!";
        }
    }
}
