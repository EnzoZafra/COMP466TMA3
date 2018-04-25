using System;
using System.Collections.Generic;

namespace part4.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public double Total { get; set; }
        public int UserId { get; set; }

        ICollection<Product> Parts { get; set; } = new List<Product>();
    }
}
