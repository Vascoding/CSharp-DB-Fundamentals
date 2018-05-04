using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstStudentSystem.Models
{
    public class License
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Resource Resource { get; set; }
    }
}
