using System;
namespace part4.Models
{
    public class Software : Product
    {
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
