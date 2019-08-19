using System;
using System.ComponentModel.DataAnnotations;

namespace Coffee_Shop.Models
{
    public class RegisterUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
