using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        private string firstname;

        private string lastname;

        private string address;

        
        private string email;

        private DateTime birthday;

        private byte[] picture;

        
        private bool medicalinsurance;

        [ForeignKey("Visitation")]
        public int VisitationId { get; set; }

        public virtual Visitation Visitation { get; set; }

        [ForeignKey("Diagnose")]
        public int DiagnoseId { get; set; }

        public virtual Diagnose Diagnose { get; set; }

        [ForeignKey("Medicament")]
        public int MedicamentId { get; set; }

        public virtual Medicament Medicament { get; set; }

        public string FirstName
        {
            get { return this.firstname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be null");
                }
                this.firstname = value;
            }
        }

        public string LastName
        {
            get { return this.lastname; }
            set { this.lastname = value; }
        }

        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email cannot be null");
                }
                this.email = value;
            }
        }

        public DateTime BirthDay
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }

        public byte[] Picture
        {
            get { return this.picture; }
            set { this.picture = value; }
        }

        public bool MedicalInsurance
        {
            get { return this.medicalinsurance; }
            set
            {
                this.medicalinsurance = value;
            }
        }
    }
}
