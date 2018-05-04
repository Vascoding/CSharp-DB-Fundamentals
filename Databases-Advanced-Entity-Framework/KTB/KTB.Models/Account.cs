using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTB.Models
{
    public class Account
    {
        public int Id { get; set; }

        public int AccountNumber { get; set; }

        public DateTime StartDate { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
