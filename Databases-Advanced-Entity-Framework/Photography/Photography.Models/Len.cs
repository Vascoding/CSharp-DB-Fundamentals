using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Models
{
    public class Len
    {
        [Key]
        public int Id { get; set; }

        public string Make { get; set; }

        public int FocalLength { get; set; }
        
        public double MaxAperture { get; set; }

        public string CompatibleWith { get; set; }

        public int? PhotographerId { get; set; }

        public virtual Photographer Photographer { get; set; }
    }
}
