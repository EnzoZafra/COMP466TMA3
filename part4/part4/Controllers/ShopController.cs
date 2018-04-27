using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using part4.Data;
using part4.Models;
using System.Linq;

namespace part4.Controllers
{
    public class ShopController : Controller
    {
        private readonly StoreContext _context;

        public ShopController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = from p in _context.Products
                                   select p;
            
            var hardware = products.Where(p => p.Type.Contains("VideoCard")
                                          || p.Type.Contains("Processor")
                                          || p.Type.Contains("Harddrive")
                                          || p.Type.Contains("RAM")
                                          || p.Type.Contains("Motherboard")
                                          || p.Type.Contains("SoundCard")
                                          || p.Type.Contains("PowerSupply"));
            var prebuilt = products.Where(p => p.Type.Contains("Computer"));
            var software = products.Where(p => p.Type.Contains("Software"));
            List<Product> peripherals = new List<Product>();

            Shop shop = new Shop(prebuilt.ToList(), hardware.ToList(), software.ToList(), peripherals);
            setLogin();
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
                List<int> productids = new List<int>();
                foreach (var part in parts)
                {
                    if (!string.IsNullOrEmpty(part))
                    {
                        // If selected none, ignore
                        if (part != "-1")
                        {
                            productids.Add(int.Parse(part));
                        }
                    }
                }
                // Make db call for part 4 (Select * from products where id in [product id array] instead of below
                var products = from p in _context.Products
                               select p;
                var selectedproducts = products.Where(p => productids.Contains(p.ProductId));
                List<Computer> comptobuy = selectedproducts.OfType<Computer>().ToList();
                List<Part> parttobuy = selectedproducts.OfType<Part>().ToList();
                List<Software> softwaretobuy = selectedproducts.OfType<Software>().ToList();

                foreach(var comp in comptobuy) {
                    productstobuy.Add(comp);
                }
                foreach (var part in parttobuy)
                {
                    productstobuy.Add(part);
                }
                foreach (var sw in softwaretobuy)
                {
                    productstobuy.Add(sw);
                }
            }

            Checkout checkout = new Checkout(productstobuy);
            setLogin();
            return View(checkout);
        }

        [HttpGet]
        public IActionResult ClearCart()
        {
            Response.Cookies.Delete("cart");
            return RedirectToAction("Checkout");
        }

        public void setLogin()
        {
            ViewBag.LoggedIn = Request.Cookies["UserID"];
        }
    }
}
