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
                if (user.Password == user.ConfirmPassword)
                {
                    if (_context.Users.Where(u => u.Username == user.Username).Any())
                    {
                        ViewBag.Message = "Username is already taken";
                        return View();
                    }
                    
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Message = user.Username + " successfully registered";
                }
                else
                {
                    ViewBag.Message = "Please confirm your password";
                }

            }
            else {
                ViewBag.Message = "Registration failed. Please check that you have " +
                    "all fields filled";
                user.ConfirmPassword = "";
            }
            return View();
        }

        // Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user) {
            if (_context.Users.Any())
            {
                var query = _context.Users.Where(u => u.Username == user.Username
                && u.Password == user.Password);
                if (!query.Any())
                {
                    ModelState.AddModelError("", "Username or password is incorrect");
                    return View();
                }
                else {
                    var usr = query.Single();
                    Response.Cookies.Delete("UserID");
                    Response.Cookies.Delete("Username");
                    Response.Cookies.Append("UserID", usr.UserId.ToString());
                    Response.Cookies.Append("Username", user.Username);
                    return RedirectToAction("LoggedIn");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("UserID");
            Response.Cookies.Delete("Username");
            return RedirectToAction("LoggedIn");
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
