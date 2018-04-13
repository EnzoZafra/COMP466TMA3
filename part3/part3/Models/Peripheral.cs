using System;
namespace part3.Models
{
    public class Peripheral : Product
    {
        public Peripheral(int pid, String name, String type, String desc, int price) 
            : base(pid, name, desc, type, price)
        {
           
        }
    }
}
