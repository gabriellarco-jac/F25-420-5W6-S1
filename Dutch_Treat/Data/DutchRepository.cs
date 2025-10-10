using Dutch_Treat.Data;
using DutchTreat.Data.Entities;


namespace DutchTreat.Data
{
    public class DutchRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<DutchRepository> _logger;

        public DutchRepository(ApplicationDbContext db, ILogger<DutchRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called...");

                return _db.Products
                            .OrderBy(p => p.Artist)
                            .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return null;
            }
        }
       

        public bool SaveAll()
        {
            //returns true when the number of states entries written to the database is > 0
            return _db.SaveChanges() > 0;
        }
    }
}
