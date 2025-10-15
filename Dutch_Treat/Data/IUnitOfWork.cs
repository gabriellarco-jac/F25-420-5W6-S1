using Dutch_Treat.Data.Repositories;

namespace Dutch_Treat.Data
{
    public interface IUnitOfWork : IDisposable
    {        
        DutchProductRepository ProductRepository { get; }
        DutchOrderRepository OrderRepository { get; }
        DutchOrderItemRepository OrderItemRepository { get; }
    }
}