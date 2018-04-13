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
            List<Part> hardware = new List<Part>();
            List<Computer> prebuilt = new List<Computer>();
            List<Software> software = new List<Software>();
            List<Peripheral> peripherals = new List<Peripheral>();

            // Hardcoded list of parts, DB for part 4
            int counter = 0;
            for (int i = 0; i < 5; i++) {
                List<Part> partlist = new List<Part>();
                Part part1 = new Part(++counter, "VideoCard " + i, "Dual HDMI, DUAL DP", "VideoCard", 499.99);
                Part part2 = new Part(++counter, "Processor " + i, "6-Core 3.2 GHz", "Processor", 374.99);
                Part part3 = new Part(++counter, "Harddrive " + i, "2 Terabyte Drive", "Harddrive", 89.99);
                Part part4 = new Part(++counter, "RAM " + i, "16GB RAM, 2x8GB DDR4", "RAM", 224.99);
                Part part5 = new Part(++counter, "Motherboard " + i, "4 DDR4 slots, Intel Slot, 2 PCIe Slots", "Motherboard", 129.99);
                Part part6 = new Part(++counter, "Sound Card" + i, "7.1 Surround Sound", "SoundCard", 49.99);
                Part part7 = new Part(++counter, "Power Supply" + i, "Gold 550w Modular", "PowerSupply", 89.99);

                Software os = new Software(++counter, "Operating System" + i, "A Windows Operating System", 119.99);
                software.Add(os);

                partlist.Add(part1);
                partlist.Add(part2);
                partlist.Add(part3);
                partlist.Add(part4);
                partlist.Add(part5);
                partlist.Add(part6);
                partlist.Add(part7);

                String desc = "This computer has a " + part1.getName() + ", " + part2.getName() + ", "
                                + part3.getName() + ", " + part4.getName() + ", " + part5.getName() + ", "
                                + part6.getName() + ", " + part7.getName() + ", " + os.getName();

                double price = 0;
                
                foreach (var item in partlist) {
                  price += item.getPrice();
                }
                price += os.getPrice();
                
                // Hardcoded list of comps
                Computer comp = new Computer(i, "Computer " + i, partlist, os, desc, price*0.9);

                prebuilt.Add(comp);
                hardware.Add(part1);
                hardware.Add(part2);
                hardware.Add(part3);
                hardware.Add(part4);
                hardware.Add(part5);
                hardware.Add(part6);
                hardware.Add(part7);

            }
            // end of hardcoded list

            Shop shop = new Shop(prebuilt, hardware, software, peripherals);

            return View(shop);
        }

        public IActionResult Checkout()
        {
            List<Part> hardware = new List<Part>();
            List<Software> software = new List<Software>();
            List<Peripheral> peripherals = new List<Peripheral>();

            // TODO: remove this for part 4
            Dictionary<String, String> temp = new Dictionary<string, string>();

            String cart = Request.Cookies["cart"];
            String[] parts = cart.Split('/');
            List<Product> productstobuy = new List<Product>();
            List<string> productids = new List<string>();
            foreach(var part in parts) {
                if (!string.IsNullOrEmpty(part)) {
                    String[] keyvaluepair = part.Split('~');
                    temp.Add(keyvaluepair[0], keyvaluepair[1]);

                    // If selected none, ignore
                    if(keyvaluepair[1] == "-1") {
                        continue;
                    }
                    else {
                        if (keyvaluepair[0] == "os")
                        {
                            // Make db call for part 4 ("Select * from software where id = keyvaluepair[1]")
                            Software os = new Software(int.Parse(keyvaluepair[1]), "Operating System" + keyvaluepair[1],
                                                       "A Windows Operating System", 119.99);
                            productstobuy.Add(os);
                        }
                        else
                        {
                            productids.Add(keyvaluepair[1]);
                        }
                    }
                }
            }
            // Make db call for part 4 (Select * from products where id in [product id array] instead of below

            // Dont need these ifstatements if using A DB
            if (temp["gpu"] != "-1")
            {
                Part part1 = new Part(int.Parse(temp["gpu"]), "VideoCard " + temp["gpu"], "Dual HDMI, DUAL DP", "VideoCard", 499.99);
                productstobuy.Add(part1);
            }
            if (temp["cpu"] != "-1")
            {
                Part part2 = new Part(int.Parse(temp["cpu"]), "Processor " + temp["cpu"], "6-Core 3.2 GHz", "Processor", 374.99);
                productstobuy.Add(part2);
            }
            if (temp["hdd"] != "-1")
            {
                Part part3 = new Part(int.Parse(temp["hdd"]), "Harddrive " + temp["hdd"], "2 Terabyte Drive", "Harddrive", 89.99);
                productstobuy.Add(part3);
            }
            if (temp["ram"] != "-1")
            {
                Part part4 = new Part(int.Parse(temp["ram"]), "RAM " + temp["ram"], "16GB RAM, 2x8GB DDR4", "RAM", 224.99);
                productstobuy.Add(part4);
            }
            if (temp["mb"] != "-1")
            {
                Part part5 = new Part(int.Parse(temp["mb"]), "Motherboard " + temp["mb"], "4 DDR4 slots, Intel Slot, 2 PCIe Slots", "Motherboard", 129.99);
                productstobuy.Add(part5);
            }
            if (temp["sc"] != "-1")
            {
                Part part6 = new Part(int.Parse(temp["sc"]), "Sound Card" + temp["sc"], "7.1 Surround Sound", "SoundCard", 49.99);
                productstobuy.Add(part6);
            }
            if (temp["psu"] != "-1")
            {
                Part part7 = new Part(int.Parse(temp["psu"]), "Power Supply" + temp["psu"], "Gold 550w Modular", "PowerSupply", 89.99);
                productstobuy.Add(part7);
            }

            Checkout checkout = new Checkout(productstobuy);
            return View(checkout);
        }
    }
}
