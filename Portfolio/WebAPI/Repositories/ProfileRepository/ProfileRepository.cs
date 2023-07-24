using Domain.DbContexts;
using Domain.Entities;

namespace WebAPI.Repositories
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(PortfolioDbContext context) : base(context) { }
    }
}
