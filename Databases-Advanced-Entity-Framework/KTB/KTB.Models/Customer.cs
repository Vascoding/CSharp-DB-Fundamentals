using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTB.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Customer
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public double Height { get; set; }

        public int? CityId { get; set; }

        public City City { get; set; }
    }
}
