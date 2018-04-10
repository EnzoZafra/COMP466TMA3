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
            Software os = new Software("Windows 10", "Newest windows 10", 199.99);
            String desc = "I'm building my own computer";
            Computer comp = new Computer("My build", partlist, os, desc);

            Configurator conf = new Configurator(comp);
            return View(conf);
        }
    }
}
