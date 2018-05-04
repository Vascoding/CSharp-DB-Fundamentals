using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSystem.Models
{
    public enum EditionType
    {
        Normal,
        Promo,
        Gold
    }

    public enum AgeRestriction
    {
        Minor,
        Teen,
        Adult
    }
    public class Book
    {
        public Book()
        {
            this.Categories = new List<Category>();
            this.RelatedBooks = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public EditionType EditionType { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<Book> RelatedBooks { get; set; }
    }
}
