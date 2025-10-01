using Dutch_Treat.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dutch_Treat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
