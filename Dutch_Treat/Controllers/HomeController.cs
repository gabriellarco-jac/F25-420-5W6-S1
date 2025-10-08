using Dutch_Treat.Data;
using Dutch_Treat.Models;
using DutchTreat.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dutch_Treat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDutchRepository _repository;

        //private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, IDutchRepository repository)
        {
            _logger = logger;
            _repository = repository;
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
            var results = _repository.GetAllProducts()
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
