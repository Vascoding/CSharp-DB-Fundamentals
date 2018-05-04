



namespace CarDealer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Part
    {
        public Part()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
