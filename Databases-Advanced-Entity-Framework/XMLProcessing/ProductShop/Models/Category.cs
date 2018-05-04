
namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
