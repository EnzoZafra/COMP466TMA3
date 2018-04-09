using System;
namespace part3.Models
{
    public enum PartType { Processor, Motherboard, VideoCard, Memory, PowerSupply};

    public class Part
    {
        private String Name;
        private PartType Type;
        private int Price;

        public Part(String name, PartType type, int price) {
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

        public PartType getType()
        {
            return Type;
        }
    }
}
