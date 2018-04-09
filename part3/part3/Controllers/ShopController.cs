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

            for (int i = 0; i < 10; i++) {
                ArrayList<Part> partlist = new ArrayList<Part>();
                Part part1 = new Part("VideoCard " + i, "VideoCard", i * 15);
                Part part2 = new Part("Processor " + i, "Processor", i * 10);
                Part part3 = new Part("PowerSupply " + i, "PowerSupply", i * 3);
                Part part4 = new Part("Memory " + i, "Memory", i * 6);
                Part part5 = new Part("Motherboard " + i, "Motherboard", i * 5);

                partlist.Add(part1);
                partlist.Add(part2);
                partlist.Add(part3);
                partlist.Add(part4);
                partlist.Add(part5);

                Computer comp = new Computer("Computer " + i, partlist);

                prebuilt.Add(comp);
                hardware.Add(part1);
                hardware.Add(part2);
                hardware.Add(part3);
                hardware.Add(part4);
                hardware.Add(part5);
            }

            Shop shop = new Shop(prebuilt, hardware);

            return View(shop);
        }
    }
}
