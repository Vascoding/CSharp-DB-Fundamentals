using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class ShowEventCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);

            AuthenticationManager.Authorize();
            string eventName = inputArgs[0];

            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            using (var context = new TeamBuilderContext())
            {
                Event e = context.Events.FirstOrDefault(s => s.Name == eventName);
                return $"{e.Name} {e.StartDate} {e.EndDate} {e.Description} \r\nTeams:\r\n-{string.Join("\r\n-", e.ParticipatingTeams.Select(t => t.Name))}";
            }
        }
    }
}
