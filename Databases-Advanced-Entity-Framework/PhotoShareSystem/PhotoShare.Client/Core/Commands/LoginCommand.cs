namespace PhotoShare.Client.Core.Commands
{
    using Service;

    public class LoginCommand
    {
        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];

            SecurityService.Login(username, password);

            return $"User {username} successfully logged in!";
        }
    }
}
