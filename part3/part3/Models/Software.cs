using System;
namespace part3.Models
{
    public class Software
    {
        private String Name;
        private String Description;
        private double Price;

        public Software(String name, String desc, double price)
        {
            this.Name = name;
            this.Description = desc;
            this.Price = price;
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
