using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTB.Models;

namespace KTB.Data.Dtos
{
    public class CustomerDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }
    }
}
