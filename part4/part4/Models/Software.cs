using System;
using System.Collections.Generic;

namespace part4.Models
{
    public class Software : Product
    {
        ICollection<Computer> Computers { get; set; } = new List<Computer>();
        public Software()
        : base()
        {
        }

        public Software(int pid, String name, String desc, double price)
            : base(pid, name, desc, "Software", price)
        {
            
        }
    }
}
