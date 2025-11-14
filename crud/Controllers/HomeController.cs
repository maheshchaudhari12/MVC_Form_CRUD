using crud.Data;
using crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Diagnostics;

namespace crud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly productDbContext _context;

        public HomeController(ILogger<HomeController> logger,productDbContext context)
        {
            _logger = logger;

            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Product p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            var pro = new Product
            {
                //productId = p.productId,
                productName = p.productName,
                Description = p.Description,
                Category = p.Category,
                productPrice = p.productPrice
            };
            _context.products.Add(pro);
            _context.SaveChanges();
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public IActionResult ProductTable()
        {
            var prod = _context.products.ToList();
            return View(prod);
        }

       

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var x = _context.products.Find(id);
            _context.products.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("ProductTable");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var prod = _context.products.Find(id);
            return View(prod);
        }

        [HttpPost]
        public IActionResult Edit(int pid, Product p)
        {
            var prod = _context.products.Find(pid);
            prod = new Product
            {
                productId = p.productId,
                productName =p.productName,
                productPrice =p.productPrice,
                Description =p.Description,
                Category =p.Category
            };

            _context.products.Update(prod);
            _context.SaveChanges();
            return RedirectToAction("ProductTable");
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
