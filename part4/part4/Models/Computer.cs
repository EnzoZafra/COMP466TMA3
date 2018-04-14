using System;
using System.Collections.Generic;

namespace part4.Models
{
    public class Computer : Product
    {
        private List<Part> Parts { get; set; }
        private Software OperatingSystem { get; set; }

        public Computer() {
          this.Parts = new List<Part>();
        }
        
        public Computer(int compid, String name, List<Part> parts, Software os, String desc, double price)
        : base(compid, name, desc, "Computer", price)
        {
            this.Parts = parts;
            this.OperatingSystem = os;
        }

        public Software getOperatingSystem()
        {
            return OperatingSystem;
        }

        public List<Part> getParts()
        {
            return Parts;
        }

        public void setOperatingSystem(Software os)
        {
            this.OperatingSystem = os;
        }
        
        public void setParts(List<Part> partslist)
        {
           this.Parts = partslist;
        }
    }
}
