using Dutch_Treat.Data.Interfaces;
using Dutch_Treat.Data.Repositories;

namespace Dutch_Treat.Data
{
    public interface IUnitOfWork : IDisposable
    {        
        T GetRepository<T>() where T : class;
        //DutchProductRepository ProductRepository { get; }
        //DutchOrderRepository OrderRepository { get; }
        //DutchOrderItemRepository OrderItemRepository { get; }
    }
}