using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class LoginCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            string userName = inputArgs[0];
            string password = inputArgs[1];

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            User user = this.GetUserByCredentials(userName, password);

            if (user == null)
            {
                throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
            }

            AuthenticationManager.Login(user);

            return $"User {user.Username} successfully logged in!";
        }

        private User GetUserByCredentials(string userName, string password)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Users.FirstOrDefault(u => u.Username == userName && u.Password == password && u.IsDeleted == false);
            }
        }
    }
}
