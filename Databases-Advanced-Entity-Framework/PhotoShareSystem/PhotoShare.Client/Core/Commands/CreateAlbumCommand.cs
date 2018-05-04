using System.Linq;
using PhotoShare.Client.Utilities;
using PhotoShare.Models;
using PhotoShare.Service;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class CreateAlbumCommand
    {
        private UserService userService;
        private TagService tagService;
        private AlbumService albumService;

        public CreateAlbumCommand(UserService userService, TagService tagService, AlbumService albumService)
        {
            this.userService = userService;
            this.tagService = tagService;
            this.albumService = albumService;
        }
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            string userName = data[0];
            string albumTitle = data[1];
            string backgroundColor = data[2];
            string[] tags = data.Skip(3).ToArray();

            if (!this.userService.IsExisting(userName))
            {
                throw new ArgumentException($"User {userName} not found!");
            }
            Color color;
            bool isColorValid = Enum.TryParse(backgroundColor, out color);

            if (!isColorValid)
            {
                throw new ArgumentException($"Color {color} not found!");
            }

            if (tags.Any(t => !this.tagService.IsTagExisting(t.ValidateOrTransform())))
            {
                throw new ArgumentException("Invalid tags!");
            }

            if (this.albumService.IsAlbumExists(albumTitle))
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            
            if (SecurityService.GetCurrentUser().Username != userName)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            this.albumService.AddAlbum(albumTitle, userName, color, tags);

            return $"Album {albumTitle} successfully created!";
        }
    }
}
