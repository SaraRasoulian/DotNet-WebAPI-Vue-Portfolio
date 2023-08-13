using Infrastructure.DbContexts;
using Application.Interfaces;

namespace Infrastructure.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly PortfolioDbContext _dbContext;
        public UnitOfWork(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
