using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly PortfolioDbContext _dbContext;
        public ProfileRepository(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Profile?> Get()
        {
            return await _dbContext.Profiles.AsNoTracking().FirstOrDefaultAsync();
        }

        public void Update(Profile model)
        {
            _dbContext.Profiles.Update(model);
        }
    }
}
