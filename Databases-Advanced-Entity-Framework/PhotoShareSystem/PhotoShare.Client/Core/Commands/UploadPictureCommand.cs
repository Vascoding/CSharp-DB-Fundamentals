using PhotoShare.Service;
using PhotoShare.Services;

namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class UploadPictureCommand
    {
        private AlbumService albumService;

        public UploadPictureCommand(AlbumService albumService)
        {
            this.albumService = albumService;
        }
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public string Execute(string[] data)
        {
            string albumName = data[0];
            string picTitle = data[1];
            string filePath = data[2];

            if (!this.albumService.IsAlbumExists(albumName))
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }

            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            this.albumService.AddPictureToAlbum(albumName, picTitle, filePath);

            return $"Picture {picTitle} added to {albumName}!";
        }
    }
}
