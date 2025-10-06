using Dutch_Treat.Data;
using Dutch_Treat.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dutch_Treat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            ViewBag.Header = "Contact Us Today";
            return View();
        }

        [HttpPost("Contact")]
        public IActionResult Contact(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                return View("Success", contact);
            }
            return View();
        }

        public IActionResult Shop()
        {
            var results = _db.Products
                .OrderBy(p => p.Category)
                .ToList();

            return View(results);
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
