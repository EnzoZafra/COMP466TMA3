using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace part4.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)] 
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)] 
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email required")]
        [DataType(DataType.EmailAddress)] 
        public string Email { get; set; }

        [Required(ErrorMessage = "Security Question required")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Security Answer required")]
        public string Answer { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
