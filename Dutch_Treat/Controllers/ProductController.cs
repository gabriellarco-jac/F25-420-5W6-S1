using Dutch_Treat.Data;
using Dutch_Treat.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dutch_Treat.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDutchProductRepository _repository;
        private IUnitOfWork _unitOfWork;

        public ProductController(ILogger<HomeController> logger, IUnitOfWork unitOfWork) //, IDutchProductRepository repository)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.ProductRepository;
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
