


namespace Photographer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Attributes;
    public class Tag
    {
        public Tag()
        {
            this.Albums = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }
        
        [Tag]
        [Column(TypeName = "VARCHAR")]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
