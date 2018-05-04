using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class KickMemberCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            string userName = inputArgs[1];
            if (!CommandHelper.IsUserExisting(userName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UserNotFound, userName));
            }

            if (!CommandHelper.IsMemberOfTeam(teamName, userName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.NotPartOfTeam, userName, teamName));
            }

            if (!CommandHelper.IsUserCreatorOfTeam(teamName, AuthenticationManager.GetCurrentUser()))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            if (AuthenticationManager.GetCurrentUser().Username == userName)
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.CommandNotAllowed, "DisbandTeam"));
            }

            this.KickMemberFromTeam(teamName, userName);

            return $"User {userName} was kicked from {teamName}!";
        }

        private void KickMemberFromTeam(string teamName, string userName)
        {
            using (var context = new TeamBuilderContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);
                User user = context.Users.FirstOrDefault(u => u.Username == userName);

                team.Members.Remove(user);
                context.SaveChanges();
            }
        }
    }
}
