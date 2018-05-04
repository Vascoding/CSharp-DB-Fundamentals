using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Diagnose
    {

        public Diagnose()
        {
            this.Patients = new HashSet<Patient>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        private string name;

        private string comment;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Diagnose can't exist without a name!");
                }
                this.name = value;
            }
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
