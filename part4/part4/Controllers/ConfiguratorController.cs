using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using Microsoft.EntityFrameworkCore;
using part4.Data;
using part4.Models;

namespace part4.Controllers
{
    public class ConfiguratorController : Controller
    {

        private readonly StoreContext _context;

        public ConfiguratorController(StoreContext context)
        {
            _context = context;
        }
    
        public IActionResult Index()
        {
            var products = from p in _context.Products
                       select p;
            var parts = products.OfType<Part>();
            var softwares = products.OfType<Software>();

            Computer comp = new Computer();
            Dictionary<int, double> pricelist = new Dictionary<int, double>();

            List<Part> gpus = parts.Where(p => p.Type.Equals("VideoCard")).ToList();
            List<Part> cpus = parts.Where(p => p.Type.Equals("Processor")).ToList();
            List<Software> oss = softwares.ToList();
            List<Part> rams = parts.Where(p => p.Type.Equals("RAM")).ToList();
            List<Part> hdds = parts.Where(p => p.Type.Equals("Harddrive")).ToList();
            List<Part> mbs = parts.Where(p => p.Type.Equals("Motherboard")).ToList();
            List<Part> scs = parts.Where(p => p.Type.Equals("SoundCard")).ToList();
            List<Part> pss = parts.Where(p => p.Type.Equals("PowerSupply")).ToList();

            foreach(var i in gpus) {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in cpus)
            {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in oss)
            {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in rams)
            {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in hdds)
            {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in mbs)
            {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in scs)
            {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in pss)
            {
                pricelist[i.ProductId] = i.Price;
            }

            Configurator conf = new Configurator(comp, cpus, mbs, rams, hdds,
                                                 gpus, pss, scs, oss, pricelist);
          return View(conf);
        }

        [HttpPost]
        public IActionResult Index(string cid)
        {
            Computer comp = new Computer();
            var products = from p in _context.Products
                           select p;
            var parts = products.OfType<Part>();
            var softwares = products.OfType<Software>();
            
            if(!string.IsNullOrEmpty(cid)) {
                int cidint = int.Parse(cid);
                var test = products.OfType<Computer>().Where(p => p.ProductId.Equals(cidint)).First();
                comp = products.OfType<Computer>().Where(p => p.ProductId.Equals(cidint)).First();
                //var compparts = products.OfType<Part>().Where(p => p.ComputerProductId.Equals(comp.ProductId));
                //comp.Parts = compparts.ToList();
                //comp.OperatingSystem = products.OfType<Software>().Where(p => p.ComputerProductId.Equals(comp.ProductId)).First();

                // Get parts list from DB for a computer, then put product ID of those parts
                foreach (var part in comp.Parts) {
                    if (part.Type == "VideoCard") {
                        Response.Cookies.Append("pickedgpu", part.getProductId().ToString());
                    }
                    else if (part.Type == "Processor")
                    {
                        Response.Cookies.Append("pickedcpu", part.getProductId().ToString());
                    }
                    else if (part.Type == "Harddrive")
                    {
                        Response.Cookies.Append("pickedhdd", part.getProductId().ToString());
                    }
                    else if (part.Type == "RAM")
                    {
                        Response.Cookies.Append("pickedram", part.getProductId().ToString());
                    }
                    else if (part.Type == "Motherboard")
                    {
                        Response.Cookies.Append("pickedmb", part.getProductId().ToString());
                    }
                    else if (part.Type == "SoundCard")
                    {
                        Response.Cookies.Append("pickedsc", part.getProductId().ToString());
                    }
                    else if (part.Type == "PowerSupply")
                    {
                        Response.Cookies.Append("pickedpsu", part.getProductId().ToString());
                    }
                }
                Response.Cookies.Append("pickedos", comp.OperatingSystem.getProductId().ToString());
            }

            Dictionary<int, double> pricelist = new Dictionary<int, double>();

            List<Part> gpus = parts.Where(p => p.Type.Equals("VideoCard")).ToList();
            List<Part> cpus = parts.Where(p => p.Type.Equals("Processor")).ToList();
            List<Software> oss = softwares.ToList();
            List<Part> rams = parts.Where(p => p.Type.Equals("RAM")).ToList();
            List<Part> hdds = parts.Where(p => p.Type.Equals("Harddrive")).ToList();
            List<Part> mbs = parts.Where(p => p.Type.Equals("Motherboard")).ToList();
            List<Part> scs = parts.Where(p => p.Type.Equals("SoundCard")).ToList();
            List<Part> pss = parts.Where(p => p.Type.Equals("PowerSupply")).ToList();

            foreach (var i in gpus)
            {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in cpus)
            {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in oss)
            {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in rams)
            {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in hdds)
            {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in mbs)
            {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in scs)
            {
                pricelist[i.ProductId] = i.Price;
            }
            foreach (var i in pss)
            {
                pricelist[i.ProductId] = i.Price;
            }

            Configurator conf = new Configurator(comp, cpus, mbs, rams, hdds,
                                                 gpus, pss, scs, oss, pricelist);
            return View(conf);
        }

        [HttpGet]
        public IActionResult ClearSelection()
        {
            Response.Cookies.Delete("pickedps");
            Response.Cookies.Delete("pickedgpu");
            Response.Cookies.Delete("pickedcpu");
            Response.Cookies.Delete("pickedhdd");
            Response.Cookies.Delete("pickedram");
            Response.Cookies.Delete("pickedmb");
            Response.Cookies.Delete("pickedsc");
            Response.Cookies.Delete("pickedpsu");
            Response.Cookies.Delete("pickedos");

            return RedirectToAction("Index");
        }
    }
}
