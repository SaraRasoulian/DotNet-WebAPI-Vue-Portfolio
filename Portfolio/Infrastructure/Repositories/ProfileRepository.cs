using Application.Interfaces;
using Infrastructure.Data.DbContexts;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(PortfolioDbContext context) : base(context) { }
    }
}
