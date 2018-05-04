using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalStore.Models
{
    public class Product
    {
        public Product()
        {
        }
        public Product(string name, string distributorName, string discription, decimal price, double weight, int quantity)
        {
            this.Name = name;
            this.DistributorName = distributorName;
            this.Discription = discription;
            this.Price = price;
            this.Weight = weight;
            this.Quantity = quantity;
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string DistributorName { get; set; }

        public string Discription { get; set; }

        public decimal Price { get; set; }

        public double? Weight { get; set; }

        public int? Quantity { get; set; }

    }
}
