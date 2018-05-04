using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }
        
        [Key]
        public int Id { get; set; }

        
        private string name;

        private string specialty;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name of the doctor cannot be null");
                }
                this.name = value;
            }
        }

        public string Speciality
        {
            get { return this.specialty; }
            set { this.specialty = value; }
        }

        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
