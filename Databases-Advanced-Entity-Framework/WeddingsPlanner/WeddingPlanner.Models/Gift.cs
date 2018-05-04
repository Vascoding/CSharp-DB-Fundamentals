using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingPlanner.Models
{
    public enum Size
    {
        Small,
        Medium,
        Large,
        NotSpecified
    }
    [Table("Gifts")]
    public class Gift : Present
    {
        [Required]
        public string Name { get; set; }
        public Size? Size { get; set; }
    }
}
