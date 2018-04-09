using System;
namespace part3.Models
{
    public class Peripheral
    {
        private String Name;
        private String Type;
        private String Description;
        private int Price;

        public Peripheral(String name, String type, String desc, int price) {
            this.Name = name;
            this.Type = type;
            this.Description = desc;
            this.Price = price;
        }

        public int getPrice() {
            return Price;
        }

        public String getName()
        {
            return Name;
        }

        public String getDescription()
        {
            return Description;
        }

        public String getType()
        {
            return Type;
        }

        public override String ToString()
        {
            return this.Name;
        }
    }
}
