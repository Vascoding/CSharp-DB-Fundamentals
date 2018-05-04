using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingPlanner.Models
{
    [Table("Cash")]
    public class Cash : Present
    {
        [Required]
        public decimal Amount { get; set; }
    }
}
