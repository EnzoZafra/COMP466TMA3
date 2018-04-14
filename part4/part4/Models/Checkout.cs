using System;
using System.Collections.Generic;

namespace part4.Models
{
    public class Checkout
    {
        private List<Product> Cart { get; set; }

        public Checkout(List<Product> cart)
        {
            this.Cart = cart;
        }

        public List<Product> getCart() {
            return Cart;
        }
    }
}
