using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMapping.Models
{
    public class Employee
    {
        public Employee()
        {
            this.Subordinates = new List<Employee>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime BirthDay { get; set; }

        public string Address { get; set; }

        public bool IsOnHoliday { get; set; }

        public Employee Manager { get; set; }

        public virtual ICollection<Employee> Subordinates { get; set; }
    }
}
