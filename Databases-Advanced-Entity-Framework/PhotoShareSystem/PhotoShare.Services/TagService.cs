using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoShare.Data;
using PhotoShare.Models;

namespace PhotoShare.Services
{
    public class TagService
    {
        public bool IsTagExisting(string townName)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Tags.Any(t => t.Name == townName);
            }
        }

        public void AddTag(string tagName)
        {
            Tag newTag = new Tag();
            newTag.Name = tagName;

            using (var context = new PhotoShareContext())
            {
                context.Tags.Add(newTag);
                context.SaveChanges();
            }
        }
    }
}
