using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Models
{
    public class Accessory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int OwnerId { get; set; }
        public virtual Photographer Owner { get; set; }
    }
}
