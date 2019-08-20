using System;
using System.ComponentModel.DataAnnotations;

namespace Coffee_Shop.Models
{
    public class RegisterUser
    {
        [Required]
        [MaxLength(18, ErrorMessage = "UserName is too long")]
        [MinLength(5, ErrorMessage = "UserName is too short")]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must have more than 8 characters")]
        [MaxLength(20, ErrorMessage = "Password must have 20 or fewer characters")]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
