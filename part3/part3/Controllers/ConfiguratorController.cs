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
            ArrayList<Part> partlist = new ArrayList<Part>();
            String desc = "I'm building my own computer";
            Computer comp = new Computer("My build", partlist, null, desc);

            ArrayList<Part> gpus = new ArrayList<Part>();
            ArrayList<Part> cpus = new ArrayList<Part>();
            ArrayList<Software> oss = new ArrayList<Software>();
            ArrayList<Part> rams = new ArrayList<Part>();
            ArrayList<Part> hdds = new ArrayList<Part>();
            ArrayList<Part> mbs = new ArrayList<Part>();
            ArrayList<Part> scs = new ArrayList<Part>();
            ArrayList<Part> pss = new ArrayList<Part>();

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
    }
}
