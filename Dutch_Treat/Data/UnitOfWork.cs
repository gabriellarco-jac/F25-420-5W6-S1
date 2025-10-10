using Dutch_Treat.Data.Repositories;
using DutchTreat.Data.Entities;

namespace Dutch_Treat.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private ApplicationDbContext _context;
        private ILogger<DutchProductRepository> _loggerProduct;
        private DutchProductRepository _productRepository;

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory) 
        {
            _loggerOrder = new Logger<DutchOrderRepository>(loggerFactory);
            _loggerProduct = new Logger<DutchProductRepository>(loggerFactory);
            _context = context;
        }
        public DutchProductRepository ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                {
                    this._productRepository = new DutchProductRepository(_context, _loggerProduct);
                }
                return this._productRepository;
            }
        }

        private ILogger<DutchOrderRepository> _loggerOrder;
        private DutchOrderRepository _orderRepository;
        private bool disposedValue;

        public DutchOrderRepository OrderRepository
        {
            get
            {
                if (this._orderRepository == null)
                {
                    this._orderRepository = new DutchOrderRepository(_context, _loggerOrder);
                }
                return this._orderRepository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
