using System;
namespace part3.Models
{
    public class Part : Product
    {
        String Type;
        public Part(int pid, String name, String desc, String type, double price) 
            : base(pid, name, desc, price)
        {
            this.Type = type;
        }

        public String getType()
        {
            return Type;
        }
    }
}
