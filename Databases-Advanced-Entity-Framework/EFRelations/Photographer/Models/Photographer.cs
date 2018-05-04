
namespace Photographer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Photographer
    {
        public Photographer()
        {
            this.PhotographerAlbums = new HashSet<PhotographerAlbum>();
        }

        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime BirthDay { get; set; }

        public virtual ICollection<PhotographerAlbum> PhotographerAlbums { get; set; }
    }
}
