using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class DeclineInviteCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);

            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsInviteExisting(teamName, AuthenticationManager.GetCurrentUser()))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InviteNotFound, teamName));
            }

            this.DeclineInvite(teamName);

            return $"Invite from {teamName} declined";
        }

        private void DeclineInvite(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                User currentUser = AuthenticationManager.GetCurrentUser();

                Invitation invitation =
                    context.Invitations.FirstOrDefault(
                        i => i.Team.Name == teamName && i.InvitedUserId == currentUser.Id && i.IsActive);

                invitation.IsActive = false;
                context.SaveChanges();
            }
        }
    }
}
