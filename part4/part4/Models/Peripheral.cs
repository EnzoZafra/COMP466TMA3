using System;
namespace part4.Models
{
    public class Peripheral : Product
    {
        public Peripheral(int pid, String name, String type, String desc, int price) 
            : base(pid, name, desc, type, price)
        {
           
        }
    }
}
