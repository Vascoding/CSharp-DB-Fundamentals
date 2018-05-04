using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingPlanner.Models
{
    public enum Gender
    {
        Male,
        Female,
        NotSpecified
    }
    public class Person
    {
        public Person()
        {
            this.Invitations = new HashSet<Invitation>();
            this.Bridegrooms = new HashSet<Wedding>();
            this.Brides = new HashSet<Wedding>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(60), MinLength(1)]
        [Required]
        public string FirstName { get; set; }

        [Required, StringLength(1), MinLength(1)]
        public string MiddleNameInitial { get; set; }

        [MinLength(2)]
        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.MiddleNameInitial} {this.LastName}";
            }
        }

        public Gender Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        [NotMapped]
        public int Age { get; set; }

        public string Phone { get; set; }
        
        public string Email { get; set; }


        public virtual ICollection<Invitation> Invitations { get; set; }
        [InverseProperty("Bride")]
        public virtual ICollection<Wedding> Brides { get; set; }
        [InverseProperty("Bridegroom")]
        public virtual ICollection<Wedding> Bridegrooms { get; set; }
    }
}
