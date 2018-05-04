using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Models
{
    public class Photographer
    {
        public Photographer()
        {
            this.Lens = new HashSet<Len>();
            this.Accessories = new HashSet<Accessory>();
            this.Workshops = new HashSet<Workshop>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(50), MinLength(2)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        [ForeignKey("PrimaryCamera")]
        public int PrimaryCameraId { get; set; }
        public virtual Camera PrimaryCamera { get; set; }

        [ForeignKey("SecondaryCamera")]
        public int SecondaryCameraId { get; set; }
        public virtual Camera SecondaryCamera { get; set; }

        public virtual ICollection<Len> Lens { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }

        public virtual ICollection<Workshop> Workshops { get; set; }

        
    }
}
