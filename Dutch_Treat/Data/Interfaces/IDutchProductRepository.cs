using DutchTreat.Data.Entities;

namespace Dutch_Treat.Data.Interfaces
{
    public interface IDutchProductRepository : IDutchRepository<Product>
    {
        IEnumerable<Product> GetByCategory(string categoryName);
    }
}
