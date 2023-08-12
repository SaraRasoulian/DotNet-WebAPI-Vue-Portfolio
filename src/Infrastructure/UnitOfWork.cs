using Application.Interfaces;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private readonly IPortfolioDbContext _dbContext;
        public UnitOfWork(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> CommitAsync()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing && _dbContext != null)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }
    }
}
