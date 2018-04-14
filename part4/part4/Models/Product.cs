using System;
using System.Collections.Generic;

namespace part4.Models
{
    public abstract class Product
    {
        public string Name { get; set;  }
        public string Description { get; set; }
        public string Type { get; set;  }
        public double Price { get; set;  }
        public int productID { get; set; }

        ICollection<Product> Parts { get; } = new List<Product>();
        ICollection<Order> Orders { get; } = new List<Order>();

        protected Product() {
        }

        protected Product(int pid, string name, string desc, string type, double price)
        {
            productID = pid;
            Name = name;
            Description = desc;
            Type = type;
            Price = price;
        }

        public int getProductId()
        {
            return productID;
        }

        public String getName()
        {
            return Name;
        }

        public String getType()
        {
            return Type;
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
        
        public void setName(String name)
        {
            this.Name = name;
        }

        public void setDescription(String desc)
        {
            this.Description = desc;
        }
        
        public void setPrice(double price)
        {
            this.Price = price;
        }

        public void setType(String type)
        {
            this.Type = type;
        }
    }
}
