using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using part3.Models;

namespace part3.Controllers
{
    public class ConfiguratorController : Controller
    {
    
        public IActionResult Index()
        {
          Computer comp = new Computer();
          List<Part> partlist = new List<Part>();

          List<Part> gpus = new List<Part>();
          List<Part> cpus = new List<Part>();
          List<Software> oss = new List<Software>();
          List<Part> rams = new List<Part>();
          List<Part> hdds = new List<Part>();
          List<Part> mbs = new List<Part>();
          List<Part> scs = new List<Part>();
          List<Part> pss = new List<Part>();

          int counter = 0;
          for (int i = 0; i < 5; i++)
          {
            Part gpu = new Part(++counter, "VideoCard " + i, "Dual HDMI, DUAL DP", "VideoCard", 499.99);
            Part cpu = new Part(++counter, "Processor " + i, "6-Core 3.2 GHz", "Processor", 374.99);
            Part hdd = new Part(++counter, "Harddrive " + i, "2 Terabyte Drive", "Harddrive", 89.99);
            Part ram = new Part(++counter, "RAM " + i, "16GB RAM, 2x8GB DDR4", "RAM", 224.99);
            Part mb = new Part(++counter, "Motherboard " + i, "4 DDR4 slots, Intel Slot, 2 PCIe Slots", "Motherboard", 129.99);
            Part sc = new Part(++counter, "Sound Card" + i, "7.1 Surround Sound", "SoundCard", 49.99);
            Part ps = new Part(++counter, "Power Supply" + i, "Gold 550w Modular", "PowerSupply", 89.99);

            Software os = new Software(++counter, "Operating System" + i, "A Windows Operating System", 119.99);

            oss.Add(os);
            gpus.Add(gpu);
            cpus.Add(cpu);
            hdds.Add(hdd);
            rams.Add(ram);
            mbs.Add(mb);
            scs.Add(sc);
            pss.Add(ps);
          }


          Configurator conf = new Configurator(comp, cpus, mbs, rams, hdds,
                                              gpus, pss, scs, oss);
          return View(conf);
        }

        [HttpPost]
        public IActionResult Index(string cid)
        {
            Computer comp = new Computer();
            if(!string.IsNullOrEmpty(cid)) {
                int cidint = int.Parse(cid);
                 // This should be a database search in part 4 instead of hard code. 
                Part part1 = new Part(1, "VideoCard " + cid, "Dual HDMI, DUAL DP", "VideoCard", 499.99);
                Part part2 = new Part(2, "Processor " + cid, "6-Core 3.2 GHz", "Processor", 374.99);
                Part part3 = new Part(3, "Harddrive " + cid, "2 Terabyte Drive", "Harddrive", 89.99);
                Part part4 = new Part(4, "RAM " + cid, "16GB RAM, 2x8GB DDR4", "RAM", 224.99);
                Part part5 = new Part(5, "Motherboard " + cid, "4 DDR4 slots, Intel Slot, 2 PCIe Slots", "Motherboard", 129.99);
                Part part6 = new Part(6, "Sound Card" + cid, "7.1 Surround Sound", "SoundCard", 49.99);
                Part part7 = new Part(7, "Power Supply" + cid, "Gold 550w Modular", "PowerSupply", 89.99);
                Software os = new Software(8, "Operating System" + cid, "A Windows Operating System", 119.99);
                List<Part> partlist = new List<Part>();
                partlist.Add(part1);
                partlist.Add(part2);
                partlist.Add(part3);
                partlist.Add(part4);
                partlist.Add(part5);
                partlist.Add(part6);
                partlist.Add(part7);
                comp.setParts(partlist);
                comp.setOperatingSystem(os);

                // Get parts list from DB for a computer, then put product ID of those parts
                Response.Cookies.Append("pickedgpu", (1).ToString());
                Response.Cookies.Append("pickedcpu", (2).ToString());
                Response.Cookies.Append("pickedhdd", (3).ToString());
                Response.Cookies.Append("pickedram", (4).ToString());
                Response.Cookies.Append("pickedmb", (5).ToString());
                Response.Cookies.Append("pickedsc", (6).ToString());
                Response.Cookies.Append("pickedpsu", (7).ToString());             
                Response.Cookies.Append("pickedos", (8).ToString());

                // Hardcode ends here
            }

            List<Part> gpus = new List<Part>();
            List<Part> cpus = new List<Part>();
            List<Software> oss = new List<Software>();
            List<Part> rams = new List<Part>();
            List<Part> hdds = new List<Part>();
            List<Part> mbs = new List<Part>();
            List<Part> scs = new List<Part>();
            List<Part> pss = new List<Part>();

            // Hardcoded list of available parts, DB for part 4
            int counter = 0;
            for (int i = 0; i < 5; i++)
            {
                Part gpu = new Part(++counter, "VideoCard " + i, "Dual HDMI, DUAL DP", "VideoCard", 499.99);
                Part cpu = new Part(++counter, "Processor " + i, "6-Core 3.2 GHz", "Processor", 374.99);
                Part hdd = new Part(++counter, "Harddrive " + i, "2 Terabyte Drive", "Harddrive", 89.99);
                Part ram = new Part(++counter, "RAM " + i, "16GB RAM, 2x8GB DDR4", "RAM", 224.99);
                Part mb = new Part(++counter, "Motherboard " + i, "4 DDR4 slots, Intel Slot, 2 PCIe Slots", "Motherboard", 129.99);
                Part sc = new Part(++counter, "Sound Card" + i, "7.1 Surround Sound", "SoundCard", 49.99);
                Part ps = new Part(++counter, "Power Supply" + i, "Gold 550w Modular", "PowerSupply", 89.99);

                Software os = new Software(++counter, "Operating System" + i, "A Windows Operating System", 119.99);

                oss.Add(os);
                gpus.Add(gpu);
                cpus.Add(cpu);
                hdds.Add(hdd);
                rams.Add(ram);
                mbs.Add(mb);
                scs.Add(sc);
                pss.Add(ps);
            }
            // Hardcode ends here


            Configurator conf = new Configurator(comp, cpus, mbs, rams, hdds,
                                                gpus, pss, scs, oss);
            return View(conf);
        }
    }
}
