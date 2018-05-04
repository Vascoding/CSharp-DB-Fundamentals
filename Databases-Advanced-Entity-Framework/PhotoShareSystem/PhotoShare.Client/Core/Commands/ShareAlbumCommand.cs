using PhotoShare.Service;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ShareAlbumCommand
    {
        private AlbumService albumService;

        private UserService userService;

        public ShareAlbumCommand(AlbumService albumService, UserService userService)
        {
            this.albumService = albumService;
            this.userService = userService;
        }
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string[] data)
        {
            int albumId = int.Parse(data[0]);
            string userName = data[1];
            string permission = data[2];
            if (!this.albumService.IsAlbumExistsById(albumId))
            {
                throw new ArgumentException("Album not found!");
            }
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            if (!this.userService.IsExisting(userName))
            {
                throw new ArgumentException($"User {userName} not found!");
            }
            if (permission != "Owner" && permission != "Viewer")
            {
                throw new ArgumentException("Permission must be either “Owner” or “Viewer”!");
            }
            if (albumService.IsUserSetOnAlbum(albumId, userName, permission))
            {
                throw new InvalidOperationException($"{userName} is already set as {permission} to album {albumId}");
            }

            this.albumService.AddUserToAlbum(albumId, userName, permission);

            return $"Username {userName} added to album {albumId} ({permission})";
        }
    }
}
