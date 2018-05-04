using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core
{
    public class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
               return context.Teams.Any(t => t.Name == teamName);
            }
        }

        public static bool IsUserExisting(string userName)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Users.Any(u => u.Username == userName && u.IsDeleted == false);
            }
        }

        public static bool IsInviteExisting(string teamName, User user)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Invitations.Any(i => i.InvitedUser.Id == user.Id && i.Team.Name == teamName && i.IsActive);
            }
        }

        public static bool IsMemberOfTeam(string teamName, string userName)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.Name == teamName && t.Members.Any(u => u.Username == userName));
            }
        }

        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.Name == teamName && t.Creator.Id == user.Id);
            }
        }

        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Events.Any(t => t.Name == eventName && t.Creator.Id == user.Id);
            }
        }

        public static bool IsEventExisting(string eventName)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Events.Any(e => e.Name == eventName);
            }
        }
    }
}
