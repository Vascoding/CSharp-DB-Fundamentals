using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMapping.Models
{
    public class ManagerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<EmployeeDto> Subordinates { get; set; }

        public int SubordinateCount { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.FirstName} {this.LastName} | Employees: {this.SubordinateCount}");
            foreach (var subordinate in Subordinates)
            {
                sb.AppendLine(subordinate.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
