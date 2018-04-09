﻿using System;
namespace part3.Models
{
    public class Part
    {
        private String Name;
        private String Type;
        private double Price;

        public Part(String name, String type, double price) {
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }

        public double getPrice() {
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

        public override String ToString()
        {
            return this.Name;
        }
    }
}
