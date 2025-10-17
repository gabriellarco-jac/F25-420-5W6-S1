using Dutch_Treat.Controllers.Base;
using Dutch_Treat.Data;
using Dutch_Treat.Data.Interfaces;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dutch_Treat.Controllers
{
    public class ProductController : BaseController<Product>
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IDutchProductRepository _repository;
        private IUnitOfWork _unitOfWork;

        public ProductController(ILogger<ProductController> logger, 
            IUnitOfWork unitOfWork) 
            : base(logger, unitOfWork.GetRepository<IDutchRepository<Product>>())
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _repository = (IDutchProductRepository)_unitOfWork.GetRepository<IDutchRepository<Product>>();
        }

        public override IActionResult Index()
        {
            var results = _repository.GetAll()
                .OrderBy(p => p.Category)
                .ToList();

            return View(results);
        }
    }
}
