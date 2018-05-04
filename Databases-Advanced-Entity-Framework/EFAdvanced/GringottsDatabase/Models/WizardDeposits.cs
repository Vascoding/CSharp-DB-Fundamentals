using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDatabase
{
    public class WizardDeposits
    {
        
        [Key]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        [Required]
        public int Age { get; set; }

        [StringLength(100)]
        public string MagicWandCreator { get; set; }

        public int MagicWandSize { get; set; }

        [StringLength(20)]
        public string DepositGroup { get; set; }


        public DateTime DepositStartDate { get; set; }

        public decimal DepositAmount { get; set; }

        public decimal DepositInterest { get; set; }

        public decimal DepositCharge { get; set; }

        public DateTime DepositExpirationDate { get; set; }

        public bool IsDepositExpired { get; set; }
    }
}
