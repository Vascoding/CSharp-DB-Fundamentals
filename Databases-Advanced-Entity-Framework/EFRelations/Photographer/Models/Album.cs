



namespace Photographer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Album
    {
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
            this.PhotographerAlbums = new HashSet<PhotographerAlbum>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<PhotographerAlbum> PhotographerAlbums { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
