using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using part4.Data;
using part4.Models;

namespace part4.Controllers
{
    public class AccountController : Controller
    {
        private readonly StoreContext _context;

        public AccountController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // For testing
            return View(_context.Users.ToList());
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid) {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.Message = user.Username + " successfully registered";
            return View();
        }

        // Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user) {
            var usr = _context.Users.Single(u => u.Username == user.Username 
                                            && u.Password == user.Password);
            if (usr != null) {
                Response.Cookies.Delete("UserID");
                Response.Cookies.Delete("Username");
                Response.Cookies.Append("UserID", usr.UserId.ToString());
                Response.Cookies.Append("Username", user.Username);
                return RedirectToAction("LoggedIn");
            }
            else {
                ModelState.AddModelError("", "Username or password is incorrect");
            }
            return View();
        }

        public IActionResult LoggedIn() {
            if (Request.Cookies["UserID"] != null) {
                return RedirectToAction("Index", "Home");
            }
            else {
                return RedirectToAction("Login");
            }
        }
    }
}
