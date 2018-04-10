using System;
namespace part3.Models
{
    public abstract class Product
    {
        private String Name;
        private String Description;
        private double Price;
        private int ProductId;

        protected Product(int pid, string name, string desc, double price)
        {
            ProductId = pid;
            Name = name;
            Description = desc;
            Price = price;
        }

        public int getProductId()
        {
            return ProductId;
        }

        public String getName()
        {
            return Name;
        }

        public String getDescription()
        {
            return Description;
        }

        public double getPrice()
        {
            return Price;
        }

        public override String ToString()
        {
            return this.Name;
        }
    }
}
