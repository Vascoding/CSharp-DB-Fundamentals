using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTB.Models
{
    public class Loan
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public decimal Amount { get; set; }

        public decimal Interests { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
