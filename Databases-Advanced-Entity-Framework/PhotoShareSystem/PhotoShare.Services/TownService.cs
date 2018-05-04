
using System.Linq;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Services
{
    public class TownService
    {
        public void Add(string name, string countryName)
        {
            Town town = new Town
            {
                Name = name,
                Country = countryName
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                context.Towns.Add(town);
                context.SaveChanges();
            }
        }
        public bool IsExisting(string townName)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Towns.Any(t => t.Name == townName);
            }
        }

        public Town GetTown(string name)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Towns.FirstOrDefault(t => t.Name == name);
            }
        }
    }
}
