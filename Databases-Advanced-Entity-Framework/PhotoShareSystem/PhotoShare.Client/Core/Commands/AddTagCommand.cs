using System;
using PhotoShare.Service;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{


    using Utilities;

    public class AddTagCommand
    {
        private TagService tagService;

        public AddTagCommand(TagService tagService)
        {
            this.tagService = tagService;
        }
        // AddTag <tag>
        public string Execute(string[] data)
        {

            string tagName = data[0].ValidateOrTransform();

            if (this.tagService.IsTagExisting(tagName))
            {
                throw new ArgumentException($"Tag {tagName} exists!");
            }
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            this.tagService.AddTag(tagName);


            return tagName + " was added successfully to database!";
        }
    }
}
