using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class Customer
    {
        public Customer()
        {
            this.SalesOfCustomers = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public int Age { get; set; }
        
        public virtual ICollection<Sale> SalesOfCustomers { get; set; }
    }
}
    