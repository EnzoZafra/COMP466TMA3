using System;
using System.Collections.Generic;

namespace part3.Models
{
    public class Checkout
    {
        private List<Product> Cart;

        public Checkout(List<Product> cart)
        {
            this.Cart = cart;
        }

        public List<Product> getCart() {
            return Cart;
        }
    }
}
