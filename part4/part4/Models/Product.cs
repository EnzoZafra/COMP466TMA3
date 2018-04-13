using System;
namespace part3.Models
{
    public abstract class Product
    {
        private String Name;
        private String Description;
        private String Type;
        private double Price;
        private int ProductId;
        
        protected Product() {
        }

        protected Product(int pid, string name, string desc, string type, double price)
        {
            ProductId = pid;
            Name = name;
            Description = desc;
            Type = type;
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
