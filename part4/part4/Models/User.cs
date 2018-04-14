using System;
using System.Collections.Generic;

namespace part4.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}
