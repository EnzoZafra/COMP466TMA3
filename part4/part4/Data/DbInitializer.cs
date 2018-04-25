using System;
using System.Collections.Generic;
using System.Linq;
using part4.Models;

namespace part4.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{Username="enzo", Password="zafra", Question="Whats your fathers maiden name", Answer="santos"}
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }

            // Add parts
            for (int i = 0; i < 5; i++)
            {
                List<Part> partslist = new List<Part>();
                Part gpu = new Part { Name = "VideoCard " + i, Description = "Dual HDMI, DUAL DP", Type = "VideoCard", Price = 499.99 };
                Part cpu = new Part { Name = "Processor " + i, Description = "6-Core 3.2 GHz", Type = "Processor", Price = 374.99 };
                Part hdd = new Part { Name = "Harddrive " + i, Description = "2 Terabyte Drive", Type = "Harddrive", Price = 89.99 };
                Part ram = new Part { Name = "RAM " + i, Description = "16GB RAM, 2x8GB DDR4", Type = "RAM", Price = 224.99 };
                Part mb = new Part { Name = "Motherboard " + i, Description = "4 DDR4 slots, Intel Slot, 2 PCIe Slots", Type = "Motherboard", Price = 129.99 };
                Part sc = new Part { Name = "Sound Card" + i, Description = "7.1 Surround Sound", Type = "SoundCard", Price = 49.99 };
                Part ps = new Part { Name = "Power Supply" + i, Description = "Gold 550w Modular", Type = "PowerSupply", Price = 89.99 };

                Software os = new Software { Name = "Operating System" + i, Description = "A Windows Operating System", Type = "Software", Price = 119.99 };

                partslist.Add(gpu);
                partslist.Add(cpu);
                partslist.Add(hdd);
                partslist.Add(ram);
                partslist.Add(mb);
                partslist.Add(sc);
                partslist.Add(ps);

                double price = 0;
                foreach(Part p in partslist) {
                    //context.Products.Add(p);
                    price += p.getPrice();
                }
   
                price += os.getPrice();
                Computer comp = new Computer { Name = "Computer " + i, Description = "Prebuilt computer with parts " + i, 
                    Price = price * 0.9, Type = "Computer" , Parts = partslist, OperatingSystem = os};
                context.Products.Add(comp);
            }
            context.SaveChanges();
        }
    }
}
