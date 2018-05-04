using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Medicament
    {

        public Medicament()
        {
            this.Patients = new HashSet<Patient>();
        }
        [Key] public int Id { get; set; }

        
        private string name;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Medicaments can't exist without a name!");
                }
                this.name = value;
            }
        }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
