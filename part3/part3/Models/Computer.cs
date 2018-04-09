using System;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace part3.Models
{
    public class Computer
    {
        private String Name { get; set; }
        private ArrayList<Part> Parts { get; set; }
        private String Description { get; set; }
        private Software OperatingSystem { get; set; }

        public Computer(String name, ArrayList<Part> parts, Software os, String desc)
        {
            this.Name = name;
            this.Parts = parts;
            this.OperatingSystem = os;
            this.Description = desc;
        }

        public String getName()
        {
            return Name;
        }

        public Software getOperatingSystem()
        {
            return OperatingSystem;
        }

        public String getDescription()
        {
            return Description;
        }

        public double getPrice()
        {
            double sum = 0;
            foreach (Part item in Parts) sum += item.getPrice();
            sum += OperatingSystem.getPrice();

            return sum;
        }

        public ArrayList<Part> getParts()
        {
            return Parts;
        }
    }
}
