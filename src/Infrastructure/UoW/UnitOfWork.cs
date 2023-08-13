using Infrastructure.DbContexts;
using Application.Interfaces;

namespace Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private readonly PortfolioDbContext _dbContext;
        public UnitOfWork(PortfolioDbContext dbContext) => _dbContext = dbContext;

        public async Task<int> CommitAsync()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
            return await _dbContext.SaveChangesAsync();
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
