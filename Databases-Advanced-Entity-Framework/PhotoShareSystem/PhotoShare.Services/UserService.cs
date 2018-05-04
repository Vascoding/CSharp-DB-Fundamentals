using System;
using System.Data.Entity;
using System.Linq;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Services
{
    public class UserService
    {
        public void Add(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool IsExisting(string username)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public User GetUser(string name)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users.SingleOrDefault(u => u.Username == name);
            }
        }
        public void ModifyUser(User user)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User findUser = context.Users.Include("BornTown").Include("CurrentTown").SingleOrDefault(u => u.Id == user.Id);

                if (findUser != null)
                {
                    if (user.Password != findUser.Password)
                    {
                        findUser.Password = user.Password;
                    }
                    
                    if (user.BornTown != null && (findUser.BornTown == null || user.BornTown.Id != findUser.BornTown.Id))
                    {
                        findUser.BornTown = context.Towns.Find(user.BornTown.Id);
                    }
                    if (user.CurrentTown != null && (findUser.CurrentTown == null || user.CurrentTown.Id != findUser.CurrentTown.Id))
                    {
                        findUser.CurrentTown = context.Towns.Find(user.CurrentTown.Id);
                    }
                    context.SaveChanges();
                }
            }
        }

        public void Remove(string userName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User findUser = context.Users.SingleOrDefault(u => u.Username == userName);
                if (findUser == null)
                {
                    throw new ArgumentException($"User {userName} not found!");
                }
                if (findUser.IsDeleted != null && findUser.IsDeleted.Value)
                {
                    throw new InvalidOperationException($"User {userName} is already deleted!");
                }
                findUser.IsDeleted = true;
                context.SaveChanges();
            }
        }

        public void MakeFriends(string firstUserName, string secondUserName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User firstUser = context.Users.Include("Friends").SingleOrDefault(u => u.Username == firstUserName);
                User secondUser = context.Users.Include("Friends").SingleOrDefault(u => u.Username == secondUserName);
                if (firstUser == null)
                {
                    throw new ArgumentException($"{firstUserName} not found!");
                }
                if (secondUser == null)
                {
                    throw new ArgumentException($"{secondUserName} not found!");
                }
                if (firstUser.Friends.Contains(secondUser))
                {
                    throw new InvalidOperationException($"{secondUserName} is already a friend to {firstUserName}");
                }

                firstUser.Friends.Add(secondUser);
                context.SaveChanges();
            }
        }

        public string ListFriends(string userName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                User user = GetUser(userName);
                if (user == null)
                {
                    throw new ArgumentException($"User {userName} not found!");
                }

                var friends = context.Users.SingleOrDefault(u => u.Username == userName).Friends.Select(f => f.Username).ToList();

                if (friends.Count == 0)
                {
                    return "No friends for this user. :(";
                }
                 return $"Friends:\n-{string.Join("\n-",friends)}";
                
            }
        }
    }
}
