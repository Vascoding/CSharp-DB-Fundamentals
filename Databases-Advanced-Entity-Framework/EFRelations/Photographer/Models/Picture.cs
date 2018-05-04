

namespace Photographer.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Picture
    {
        public Picture()
        {
            this.Albums = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Caption { get; set; }

        public string FilePath { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
