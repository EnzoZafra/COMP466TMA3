using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using part4.Data;
using part4.Models;

namespace part4.Controllers
{
    public class HomeController : Controller
    {
        private readonly StoreContext _context;

        public HomeController(StoreContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            setLogin();
            return View(await _context.Users.ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Need help? Contact us.";
            setLogin();
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void setLogin()
        {
            ViewBag.LoggedIn = Request.Cookies["UserID"];
        }
    }
}
