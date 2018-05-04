using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class CreateEventCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(6, inputArgs);

            AuthenticationManager.Authorize();

            string eventName = inputArgs[0];
            string description = inputArgs[1];

            DateTime startDateTime;

            bool isStartDateTime = DateTime.TryParseExact(inputArgs[2] + " " + inputArgs[3], Constants.DateTimeFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out startDateTime);

            DateTime endDateTime;

            bool isEndDateTime = DateTime.TryParseExact(inputArgs[4] + " " + inputArgs[5], Constants.DateTimeFormat,
               CultureInfo.InvariantCulture, DateTimeStyles.None, out endDateTime);

            if (!isEndDateTime || !isStartDateTime)
            {
                throw new ArgumentException(Constants.ErrorMessages.InvalidDateFormat);
            }

            if (startDateTime > endDateTime)
            {
                throw new ArgumentException("EndDate cannot be before startdate!");
            }

            this.CreateEvent(eventName, description, startDateTime, endDateTime);

            return $"Event {eventName} was created successfully!";
        }

        private void CreateEvent(string eventName, string description, DateTime startDate, DateTime endDate)
        {
            using (var context = new TeamBuilderContext())
            {
                Event e = new Event();
                e.Name = eventName;
                e.Description = description;
                e.StartDate = startDate;
                e.EndDate = endDate;
                e.CreatorId = AuthenticationManager.GetCurrentUser().Id;

                context.Events.Add(e);
                context.SaveChanges();
            }
        }
    }
}
