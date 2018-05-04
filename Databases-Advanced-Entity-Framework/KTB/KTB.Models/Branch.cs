using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTB.Models
{
    public class Branch
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

    }
}
