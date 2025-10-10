using Dutch_Treat.Data.Interfaces;
using DutchTreat.Data.Entities;

namespace Dutch_Treat.Data.Repositories
{
    public class DutchOrderRepository : DutchGenericRepository<Order>, IDutchOrderRepository
    {
        public DutchOrderRepository(ApplicationDbContext db, ILogger<DutchGenericRepository<Order>> logger) : base(db, logger)
        {
        }
    }
}
