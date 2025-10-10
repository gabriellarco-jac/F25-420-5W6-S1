using Dutch_Treat.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dutch_Treat.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDutchProductRepository _repository;

        public ProductController(ILogger<HomeController> logger, IDutchProductRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var results = _repository.GetAll()
                .OrderBy(p => p.Category)
                .ToList();

            return View(results);
        }
    }
}
