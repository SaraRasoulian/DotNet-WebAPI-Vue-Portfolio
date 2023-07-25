using Domain.DbContexts;

namespace WebAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEducation2Repository Education2 { get; private set; }
        public IProfileRepository Profile { get; private set; }

        private readonly PortfolioDbContext _contect;
        public UnitOfWork(PortfolioDbContext context)
        {
            _contect = context;
            Education2 = new Education2Repository(_contect);
            Profile = new ProfileRepository(_contect);
        }

        public async Task<int> Save()
        {
            return await _contect.SaveChangesAsync();
        }

        public void Dispose()
        {
            _contect.DisposeAsync();
        }
    }
}
