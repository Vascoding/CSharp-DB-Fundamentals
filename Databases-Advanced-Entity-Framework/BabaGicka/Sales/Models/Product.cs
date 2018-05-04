using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class Product
    {
        public Product()
        {
            this.SalesOfProduct = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        public string Desctiption { get; set; }
        public virtual ICollection<Sale> SalesOfProduct { get; set; }
    }
}
