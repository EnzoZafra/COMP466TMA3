using System;
using System.Collections.Generic;

namespace part4.Models
{
    public class Part : Product
    {
        ICollection<Computer> computer { get; set; } = new List<Computer>();

        public Part()
         : base()
        {
        }

        public Part(int pid, String name, String desc, String type, double price) 
            : base(pid, name, desc, type, price)
        {
        }

    }
}
