using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class InviteToTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];
            string userName = inputArgs[1];

            if (!CommandHelper.IsUserExisting(userName) && !CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(Constants.ErrorMessages.TeamOrUserNotExist);
            }

            if (this.IsInvitePending(teamName, userName))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.InviteIsAlreadySent);
            }

            if (!this.IsCreatorOrPartOfTeam(teamName))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            this.SendInvite(teamName, userName);

            return $"Team {teamName} invited {userName}!";
        }

        private bool IsInvitePending(string teamName, string userName)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Invitations
                    .Include("Team")
                    .Include("InvitedUser")
                    .Any(i => i.Team.Name == teamName && i.InvitedUser.Username == userName && i.IsActive);
            }
        }

        private bool IsCreatorOrPartOfTeam(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                User curremtUser = AuthenticationManager.GetCurrentUser();

                return context.Teams
                    .Include("Members")
                    .Any(
                        t =>
                            t.Name == teamName &&
                            (t.CreatorId == curremtUser.Id || t.Members.Any(m => m.Username == curremtUser.Username)));
            }
        }

        private void SendInvite(string teamName, string userName)
        {
            using (var context = new TeamBuilderContext())
            {
                Team team = context.Teams.FirstOrDefault(t => t.Name == teamName);
                User user = context.Users.FirstOrDefault(u => u.Username == userName);

                Invitation invitation = new Invitation();
                invitation.Team = team;
                invitation.InvitedUser = user;

                if (user == team.Creator)
                {
                    team.Members.Add(user);
                    invitation.IsActive = false;    
                }
                context.Invitations.Add(invitation);
                context.SaveChanges();
            }
        }
    }
}
