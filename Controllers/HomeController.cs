using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Products");
        }


        [HttpGet("/products")]
        public IActionResult Products()
        {
            ViewBag.AllProducts = _context.Products.OrderBy(a => a.Name).ToList();
            return View("Index");
        }

        [HttpPost("/products/new")]
        public IActionResult newProduct(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.AllProducts = _context.Products.OrderBy(a => a.Name).ToList();
                return View("Index");
            }
        }



        [HttpGet("/categories")]
        public IActionResult Categories()
        {
            ViewBag.AllCategories = _context.Categories.OrderBy(a => a.Name).ToList();
            return View("Categories");
        }


        [HttpPost("/categories/new")]
        public IActionResult newCategories(Category newCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(newCategories);
                _context.SaveChanges();
                return RedirectToAction("Categories");
            }
            else
            {
                ViewBag.AllCategories = _context.Categories.OrderBy(a => a.Name).ToList();
                return View("Categories");
            }
        }


        [HttpGet("/Products/{id}")]
        public IActionResult ProductItem(int id)
        {
            return View("ProductItem");
        }



        [HttpGet("/Categories/{id}")]
        public IActionResult CategoryItem(int id)
        {
    
            return View("CategoryItem");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
