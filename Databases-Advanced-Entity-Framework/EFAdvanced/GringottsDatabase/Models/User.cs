using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDatabase.Models
{
    public class User
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 30 characters long")]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 50 characters long")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*(_|[!@#$%^&*,_+<>?])).+$", ErrorMessage = @"Password must contain at least: 
                                                                                                           1 uppercase, 1 lowercase 1 digit and 1 special symbol")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^(?!\.)(?!\-)(?!\\_).*([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = @"Invalid Email format...must be in format <user>@<host>")]
        public string Email { get; set; }

        [MaxLength(1000000, ErrorMessage = "Size of the picture is too big. Maximum size is 1MB")]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }

    }
}
