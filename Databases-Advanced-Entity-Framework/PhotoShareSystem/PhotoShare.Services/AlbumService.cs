using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Services
{
    public class AlbumService
    {
        public void AddAlbum(string albumName, string ownerName, Color color, string[] tagNames)
        {
            using (var context = new PhotoShareContext())
            {
                Album album = new Album();
                album.Name = albumName;
                album.BackgroundColor = color;
                album.Tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

                User owner = context.Users.SingleOrDefault(u => u.Username == ownerName);

                if (owner != null)
                {
                    AlbumRole albumRole = new AlbumRole();
                    albumRole.User = owner;
                    albumRole.Album = album;
                    albumRole.Role = Role.Owner;
                    album.AlbumRoles.Add(albumRole);
                    context.Albums.Add(album);
                    context.SaveChanges();
                }
            }
        }

        public bool IsAlbumExists(string albumName)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Name == albumName);
            }
        }

        public void AddTagTo(string albumName, string tagName)
        {
            using (var context = new PhotoShareContext())
            {
                Album album = context.Albums.SingleOrDefault(a => a.Name == albumName);
                Tag tag = context.Tags.SingleOrDefault(t => t.Name == tagName);
                album.Tags.Add(tag);
                context.SaveChanges();
            }
        }

        public bool IsAlbumExistsById(int albumId)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Albums.Any(a => a.Id == albumId);
            }
        }

        public bool IsUserSetOnAlbum(int albumId, string userName, string permission)
        {
            using (var context = new PhotoShareContext())
            {
                Album album = context.Albums.SingleOrDefault(a => a.Id == albumId);
                User user = context.Users.SingleOrDefault(u => u.Username == userName);
                var albumRole = context.AlbumRoles.Where(a => a.User.Id == user.Id && a.Album.Id == album.Id);
                foreach (var a in albumRole)
                {
                    if (a.Role.ToString() == permission)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void AddUserToAlbum(int albumId, string userName, string permission)
        {
            using (var context = new PhotoShareContext())
            {
                Album album = context.Albums.SingleOrDefault(a => a.Id == albumId);
                User user = context.Users.SingleOrDefault(u => u.Username == userName);
                AlbumRole addAlbumRole = new AlbumRole();

                if (album == null)
                {
                    throw new ArgumentException("Album not found!");
                }
                if (user == null)
                {
                    throw new ArgumentException($"User {userName} not found!");
                }
                if (permission != "Owner" && permission != "Viewer")
                {
                    throw new ArgumentException("Permission must be either “Owner” or “Viewer”!");
                }
                if (permission == "Owner")
                {
                    addAlbumRole.User = user;
                    addAlbumRole.Album = album;
                    addAlbumRole.Role = Role.Owner;
                    context.AlbumRoles.Add(addAlbumRole);
                }
                if (permission == "Viewer")
                {
                    addAlbumRole.User = user;
                    addAlbumRole.Album = album;
                    addAlbumRole.Role = Role.Viewer;
                    context.AlbumRoles.Add(addAlbumRole);
                }
                context.SaveChanges();
            }
        }

        public void AddPictureToAlbum(string albumName, string title, string filePath)
        {
            using (var context = new PhotoShareContext())
            {
                Album album = context.Albums.SingleOrDefault(a => a.Name == albumName);
                if (album == null)
                {
                    throw new ArgumentException($"Album {albumName} not found!");
                }
                Picture pic = new Picture();
                pic.Title = title;
                pic.Path = filePath;

                album.Pictures.Add(pic);
                context.SaveChanges();
            }
        }

        public bool IsUserOwnerOfAlbum(string username, string albumName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Album album = context.Albums
                    .Include("AlbumRoles")
                    .Include("AlbumRoles.User")
                    .SingleOrDefault(a => a.Name == albumName);

                if (album == null)
                {
                    return false;
                }

                return album.AlbumRoles.Any(ar => ar.User.Username == username && ar.Role == Role.Owner);
            }
        }
    }
}
