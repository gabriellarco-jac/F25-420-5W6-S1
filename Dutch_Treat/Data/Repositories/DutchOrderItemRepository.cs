using Dutch_Treat.Data.Interfaces;
using DutchTreat.Data.Entities;

namespace Dutch_Treat.Data.Repositories
{
    public class DutchOrderItemRepository : DutchGenericRepository<OrderItem>, IDutchOrderItemRepository
    {
        public DutchOrderItemRepository(ApplicationDbContext db, ILogger<DutchGenericRepository<OrderItem>> logger) : base(db, logger)
        {
        }
    }
}
