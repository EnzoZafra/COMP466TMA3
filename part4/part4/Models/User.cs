using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace part4.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)] 
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [NotMapped]
        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)] 
        public string ConfirmPassword { get; set; }

        [Display(Name = "Security Question")]
        [Required(ErrorMessage = "Security Question required")]
        public string Question { get; set; }

        [Display(Name = "Security Answer")]
        [Required(ErrorMessage = "Security Answer required")]
        public string Answer { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
