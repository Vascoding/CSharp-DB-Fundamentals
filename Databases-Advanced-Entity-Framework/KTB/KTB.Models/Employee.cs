using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTB.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public int BranchId { get; set; }

        public Branch Branch { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
