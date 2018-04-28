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
                List<int> productids = parseCart(cart);

                productstobuy = getProducts(productids);
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

        public IActionResult ProcessOrder()
        {
            Order neworder = new Order();

            neworder.UserId = Int32.Parse(Request.Cookies["UserID"]);
            string cart = Request.Cookies["cart"];
            if(!string.IsNullOrEmpty(cart))
            {
                List<int> productids = parseCart(cart);
                var products = from p in _context.Products
                               select p;
                var selectedproducts = products.Where(p => productids.Contains(p.ProductId));
                foreach (var item in selectedproducts)
                {
                    ProductOrder po = new ProductOrder();
                    po.Product = item;
                    po.Order = neworder;
                    _context.ProductOrders.Add(po);
                    neworder.Total += item.Price;
                }
                _context.Orders.Add(neworder);
                _context.SaveChanges();

                return RedirectToAction("Order", neworder);
            }
           
            return RedirectToAction("Checkout");
        }

        public IActionResult Order(Order order)
        {
            setLogin();
            string orderlist = TempData["orderlist"] as string;
            List<int> productids = parseCart(orderlist);
            order.Products = getProducts(productids);

            Response.Cookies.Delete("cart");
            return View(order);
        }

        public IActionResult MyOrders()
        {
            MyOrder myorder = new MyOrder();
            List<int> orderids = new List<int>();
            setLogin();
            var userorders = _context.Orders
                .Where(o => o.UserId == Int32.Parse(Request.Cookies["UserID"]));
            foreach(var item in userorders) {
                item.Products = _context.Orders
                .Where(o => o.OrderId == item.OrderId)
                .SelectMany(m => m.ProductOrders.Select(po => po.Product))
                .ToList();
            }

            myorder.Orders = userorders.ToList();
            return View(myorder);
        }

        public void setLogin()
        {
            ViewBag.LoggedIn = Request.Cookies["UserID"];
        }

        public List<int> parseCart(string cartstring)
        {
            List<int> productids = new List<int>();
            String cart = Request.Cookies["cart"];
            if (!string.IsNullOrEmpty(cart))
            {
                String[] parts = cart.Split('/');
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
            }
            return productids;
        }

        public List<Product> getProducts(List<int> productids)
        {
            List<Product> productstobuy = new List<Product>();
            var products = from p in _context.Products
                           select p;
            var selectedproducts = products.Where(p => productids.Contains(p.ProductId));
            List<Computer> comptobuy = selectedproducts.OfType<Computer>().ToList();
            List<Part> parttobuy = selectedproducts.OfType<Part>().ToList();
            List<Software> softwaretobuy = selectedproducts.OfType<Software>().ToList();

            foreach (var comp in comptobuy)
            {
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
            return productstobuy;
        }
    }
}
