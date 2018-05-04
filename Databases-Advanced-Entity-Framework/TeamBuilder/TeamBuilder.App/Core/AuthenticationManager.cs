using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core
{
    public class AuthenticationManager
    {
        private static User currentUser;

        public static void Login(User getUser)
        {
            using (var context = new TeamBuilderContext())
            {
                User user = context.Users.SingleOrDefault(u => u.Username == getUser.Username && u.Password == getUser.Password);

                if (currentUser != null)
                {
                    throw new ArgumentException(Constants.ErrorMessages.LogoutFirst);
                }

                if (user == null)
                {
                    throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
                }

                currentUser = user;
            }
        }

        public static void Logout()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }

            currentUser = null;
        }

        public static User GetCurrentUser()
        {
            return currentUser;
        }

        public static bool IsAuthenticated()
        {
            return currentUser != null;
        }
        public static void Authorize()
        {
            if (currentUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }
        }
    }
}
