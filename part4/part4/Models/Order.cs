using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace part4.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public double Total { get; set; }
        public int UserId { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

        [NotMapped]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
