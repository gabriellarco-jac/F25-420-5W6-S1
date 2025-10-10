using Dutch_Treat.Data.Repositories;

namespace Dutch_Treat.Data
{
    public interface IUnitOfWork : IDisposable
    {
        DutchOrderRepository OrderRepository { get; }
        DutchProductRepository ProductRepository { get; }
    }
}