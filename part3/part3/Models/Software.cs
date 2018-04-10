using System;
namespace part3.Models
{
    public class Software : Product
    {
        public Software(int pid, String name, String desc, double price)
            : base(pid, name, desc, price)
        {
            
        }
    }
}
