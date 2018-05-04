using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class ImportTeamsCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);

            string filePath = inputArgs[0];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format(Constants.ErrorMessages.FileNotFound, filePath));
            }

            List<Team> teams;

            try
            {
                teams = this.GetTeamsFromXml(filePath);
            }
            catch (Exception)
            {
                
                throw new FormatException(Constants.ErrorMessages.InvalidXmlFormat);
            }

            this.AddTeams(teams);
            return $"You have successfully imported {teams.Count} teams!";
        }

        private void AddTeams(List<Team> teams)
        {
            using (var context = new TeamBuilderContext())
            {
                foreach (var team in teams)
                {
                    context.Teams.Add(team);
                    context.SaveChanges();
                }
            }
        }

        private List<Team> GetTeamsFromXml(string filePath)
        {
            List<Team> teamList = new List<Team>();
            XDocument xmlDoc = XDocument.Load(filePath);
            XElement teams = xmlDoc.Root;

            foreach (var t in teams.Elements())
            {
                string teamName = t.Element("name")?.Value;
                string acronym = t.Element("acronym")?.Value;
                string description = t.Element("description")?.Value;
                int creatorId = int.Parse(t.Element("creator-id")?.Value);

                Team team = new Team()
                {
                    Name = teamName,
                    Acronym = acronym,
                    Description = description,
                    CreatorId = creatorId
                };
                teamList.Add(team);
            }

            return teamList;
        }
    }
}
