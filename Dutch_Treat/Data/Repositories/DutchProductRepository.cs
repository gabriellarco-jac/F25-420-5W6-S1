using Dutch_Treat.Data.Interfaces;
using DutchTreat.Data.Entities;

namespace Dutch_Treat.Data.Repositories
{
    public class DutchProductRepository : DutchGenericRepository<Product>, IDutchProductRepository
    {
        public DutchProductRepository(ApplicationDbContext db, ILogger<DutchGenericRepository<Product>> logger) : base(db, logger)
        {
        }

        public IEnumerable<Product> GetByCategory(string categoryName)
        {
            return _dbSet.Where(p => p.Category == categoryName)
                        .ToList();

        }
    }
}
