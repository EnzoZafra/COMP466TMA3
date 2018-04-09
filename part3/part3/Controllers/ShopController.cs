using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using part3.Models;

namespace part3.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            ArrayList<Part> hardware = new ArrayList<Part>();
            ArrayList<Computer> prebuilt = new ArrayList<Computer>();
            ArrayList<Software> software = new ArrayList<Software>();
            ArrayList<Peripheral> peripherals = new ArrayList<Peripheral>();

            for (int i = 0; i < 5; i++) {
                ArrayList<Part> partlist = new ArrayList<Part>();
                Part part1 = new Part("VideoCard " + i, "VideoCard", 499.99);
                Part part2 = new Part("Processor " + i, "Processor", 374.99);
                Part part3 = new Part("Harddrive " + i, "Harddrive", 89.99);
                Part part4 = new Part("RAM " + i, "RAM", 224.99);
                Part part5 = new Part("Motherboard " + i, "Motherboard", 129.99);
                Part part7 = new Part("Sound Card" + i, "SoundCard", 49.99);
                Part part8 = new Part("Power Supply" + i, "PowerSupply", 89.99);

                Software os = new Software("Operating System" + i, "A Windows Operating System", 119.99);
                software.Add(os);

                partlist.Add(part1);
                partlist.Add(part2);
                partlist.Add(part3);
                partlist.Add(part4);
                partlist.Add(part5);
                partlist.Add(part7);
                partlist.Add(part8);

                String desc = "This computer has a " + part1.getName() + ", " + part2.getName() + ", "
                                + part3.getName() + ", " + part4.getName() + ", " + part5.getName() + ", "
                                + part7.getName() + ", " + part8.getName() + ", " + os.getName();
                Computer comp = new Computer("Computer " + i, partlist, os, desc);

                prebuilt.Add(comp);
                hardware.Add(part1);
                hardware.Add(part2);
                hardware.Add(part3);
                hardware.Add(part4);
                hardware.Add(part5);
                hardware.Add(part7);
                hardware.Add(part8);

                String test = comp.getDescription();
                String lol = test;
            }

            Shop shop = new Shop(prebuilt, hardware, software, peripherals);

            return View(shop);
        }
    }
}
