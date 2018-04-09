using System;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace part3.Models
{
    public class Computer
    {
        private String Name { get; set; }
        private ArrayList<Part> Parts { get; set; }

        public Computer(String name, ArrayList<Part> parts)
        {
            this.Name = name;
            this.Parts = parts;
        }

        public String getName()
        {
            return Name;
        }

        public int getPrice()
        {
            int sum = 0;
            foreach (Part item in Parts) sum += item.getPrice();

            return sum;
        }

        public ArrayList<Part> getParts()
        {
            return Parts;
        }
    }
}
