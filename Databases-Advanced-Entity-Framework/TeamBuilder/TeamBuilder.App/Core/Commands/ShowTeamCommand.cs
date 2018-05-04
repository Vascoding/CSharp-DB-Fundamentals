using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class ShowTeamCommand
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

            using (var context = new TeamBuilderContext())
            {
                Team t = context.Teams.FirstOrDefault(s => s.Name == teamName);
                return $"{t.Name} {t.Acronym} \r\nMembers:\r\n{string.Join("\r\n--", t.Members.Select(m => m.Username))}";
            }
        }
    }
}
