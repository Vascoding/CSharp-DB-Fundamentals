using PhotoShare.Client.Utilities;
using PhotoShare.Service;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class AddTagToCommand
    {
        private AlbumService albumService;
        private TagService tagService;

        public AddTagToCommand(AlbumService albumService, TagService tagService)
        {
            this.albumService = albumService;
            this.tagService = tagService;
        }
        // AddTagTo <albumName> <tag>
        public string Execute(string[] data)
        {
            string albumName = data[0];
            string tagName = data[1].ValidateOrTransform();

            if (!this.albumService.IsAlbumExists(albumName) || !this.tagService.IsTagExisting(tagName.ValidateOrTransform()))
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            if (!this.albumService.IsUserOwnerOfAlbum(SecurityService.GetCurrentUser().Username, albumName))
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            this.albumService.AddTagTo(albumName, tagName);

            return $"Tag {tagName} added to {albumName}!";
        }
    }
}
