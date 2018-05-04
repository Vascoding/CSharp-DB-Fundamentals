using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class ExportTeamCommand
    {
        public string Execute(string[] inputArgs)
        {
            string teamName = string.Join(" ", inputArgs);
            
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            Team team = this.GetTeamByName(teamName);

            this.ExportTeam(team);
            return $"Team {team.Name} exported!";
        }

        private void ExportTeam(Team team)
        {
            string json = JsonConvert.SerializeObject(new
            {
                Name = team.Name,
                Acronym = team.Acronym,
                Members = team.Members.Select(m => m.Username)
            }, Formatting.Indented);
            File.WriteAllText("team.json", json);
        }

        private Team GetTeamByName(string teamName)
        {
            using (var context = new TeamBuilderContext())
            {
                return context.Teams.Include("Members").FirstOrDefault(t => t.Name == teamName);
            }
        }   
    }
}
