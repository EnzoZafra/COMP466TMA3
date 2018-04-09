using System;
namespace part3.Models
{
    public class Part
    {
        private String Name;
        private String Type;
        private int Price;

        public Part(String name, String type, int price) {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }

        public int getPrice() {
            return Price;
        }

        public String getName()
        {
            return Name;
        }

        public String getType()
        {
            return Type;
        }
    }
}
