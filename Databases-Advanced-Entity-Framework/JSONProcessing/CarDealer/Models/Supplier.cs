

namespace CarDealer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Supplier
    {
        public Supplier()
        {
            this.Parts = new HashSet<Part>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsImporter { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
