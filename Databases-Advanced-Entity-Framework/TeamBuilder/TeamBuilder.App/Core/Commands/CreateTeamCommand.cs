using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class CreateTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            if (inputArgs.Length != 2 && inputArgs.Length != 3)
            {
                throw new ArgumentException(nameof(inputArgs));
            }

            AuthenticationManager.Authorize();

            string teamName = inputArgs[0];

            if (CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamExists, teamName));
            }

            string acronym = inputArgs[1];

            if (acronym.Length != 3)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InvalidAcronym, acronym));
            }

            string description = inputArgs.Length == 3 ? inputArgs[2] : null;
            this.AddTeam(teamName, acronym, description);

            return $"Team {teamName} successfully created";
        }

        private void AddTeam(string teamName, string acronym, string description)
        {
            using (var context = new TeamBuilderContext())
            {
                Team team = new Team();
                team.Name = teamName;
                team.Acronym = acronym;
                team.Description = description;
                team.CreatorId = AuthenticationManager.GetCurrentUser().Id;
                context.Teams.Add(team);
                context.SaveChanges();
            }
        }
    }
}
