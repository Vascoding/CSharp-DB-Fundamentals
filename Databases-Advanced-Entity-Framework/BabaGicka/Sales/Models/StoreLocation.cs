using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class StoreLocation
    {
        public StoreLocation()
        {
            this.SalesInStores = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }

        public string LocationName { get; set; }

        public virtual ICollection<Sale> SalesInStores { get; set; }
    }
}
