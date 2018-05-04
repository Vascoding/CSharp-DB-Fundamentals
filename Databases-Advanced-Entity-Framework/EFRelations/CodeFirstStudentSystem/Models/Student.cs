using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstStudentSystem.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? BirthDay { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
