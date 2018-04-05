using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using part2.Models;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace part2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;

        public HomeController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            var builder = new ConfigurationBuilder().SetBasePath(_appEnvironment.WebRootPath).AddJsonFile("img/images.txt");
            IConfigurationRoot Configuration = builder.Build();
            Slideshow show = new Slideshow(Configuration);
            return View(show);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
