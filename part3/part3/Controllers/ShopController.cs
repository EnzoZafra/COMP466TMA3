using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
                Computer comp = new Computer(++counter, "Computer " + i, partlist, os, desc, price*0.9);

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

            List<Product> productstobuy = new List<Product>();
            String cart = Request.Cookies["cart"];
            if (!string.IsNullOrEmpty(cart)) {
                String[] parts = cart.Split('/');
                List<string> productids = new List<string>();
                Console.WriteLine("TEST");
                foreach (var part in parts)
                {
                    if (!string.IsNullOrEmpty(part))
                    {
                        // If selected none, ignore
                        if (part != "-1")
                        {
                            productids.Add(part);
                        }
                    }
                }
                // Make db call for part 4 (Select * from products where id in [product id array] instead of below

                // TODO: remove this for part 4
                Dictionary<int, Product> temp = new Dictionary<int, Product>();
                int counter = 0;
                for (int i = 0; i < 5; i++) {
                    Part part1 = new Part(++counter, "VideoCard " + i, "Dual HDMI, DUAL DP", "VideoCard", 499.99);
                    temp.Add(counter, part1);
                    Part part2 = new Part(++counter, "Processor " + i, "6-Core 3.2 GHz", "Processor", 374.99);
                    temp.Add(counter, part2);
                    Part part3 = new Part(++counter, "Harddrive " + i, "2 Terabyte Drive", "Harddrive", 89.99);
                    temp.Add(counter, part3);
                    Part part4 = new Part(++counter, "RAM " + i, "16GB RAM, 2x8GB DDR4", "RAM", 224.99);
                    temp.Add(counter, part4);
                    Part part5 = new Part(++counter, "Motherboard " + i, "4 DDR4 slots, Intel Slot, 2 PCIe Slots", "Motherboard", 129.99);
                    temp.Add(counter, part5);
                    Part part6 = new Part(++counter, "Sound Card" + i, "7.1 Surround Sound", "SoundCard", 49.99);
                    temp.Add(counter, part6);
                    Part part7 = new Part(++counter, "Power Supply" + i, "Gold 550w Modular", "PowerSupply", 89.99);
                    temp.Add(counter, part7);

                    Software os = new Software(++counter, "Operating System" + i, "A Windows Operating System", 119.99);
                    temp.Add(counter, os);


                    List<Part> partlist = new List<Part>();
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

                    foreach (var item in partlist)
                    {
                        price += item.getPrice();
                    }
                    price += os.getPrice();

                    // Hardcoded list of comps
                    Computer comp = new Computer(++counter, "Computer " + i, partlist, os, desc, price * 0.9);
                    temp.Add(counter, comp);
                }
                // end of hardcoded list
                foreach(string pid in productids) {
                    Product p = temp[int.Parse(pid)];
                    if (p != null) {
                        productstobuy.Add(p);
                    }
                }
            }

            Checkout checkout = new Checkout(productstobuy);
            return View(checkout);
        }

        [HttpGet]
        public IActionResult ClearCart()
        {
            Response.Cookies.Delete("cart");
            return RedirectToAction("Checkout");
        }
    }
}
