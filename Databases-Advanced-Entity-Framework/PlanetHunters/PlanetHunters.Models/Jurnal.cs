using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
{
    public class Jurnal
    {
        public Jurnal()
        {
            this.Publications = new HashSet<Publication>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual  ICollection<Publication> Publications { get; set; }
    }
}
