using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using part1.Models;

namespace part1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int visits = 0; 
            String visitcount = Request.Cookies["VisitCount"];
            if (visitcount != null) {
                visits = Int32.Parse(visitcount);
                visits++;

            }
            else {
                visits = 1;
            }
            Response.Cookies.Delete("VisitCount");
            Response.Cookies.Append("VisitCount", (visits).ToString());

            ViewData["VisitCount"] = visits;
            ViewData["IPAddr"] = Request.HttpContext.Connection.LocalIpAddress;
            ViewData["Timezone"] = Request.Cookies["timezone"];
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
