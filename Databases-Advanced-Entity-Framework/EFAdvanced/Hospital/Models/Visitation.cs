using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Hospital.Models
{
    public class Visitation
    {
        public Visitation()
        {
            this.Patients = new HashSet<Patient>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        private DateTime date;

        private string comment;

        public DateTime Date
        {
            get { return this.date; }
            set
            {
                if (value.Equals(null))
                {
                    throw new ArgumentException("Date can't be null");
                }
                this.date = value;
            }
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }

        public virtual ICollection<Patient> Patients { get; set; }

        [Index(IsUnique = true)]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
