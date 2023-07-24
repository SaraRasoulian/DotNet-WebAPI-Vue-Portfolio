using Domain.DbContexts;
using Domain.Entities;

namespace WebAPI.Repositories
{
    public class Education2Repository : GenericRepository<Education>, IEducation2Repository
    {
        public Education2Repository(PortfolioDbContext context) : base(context)
        {
            
        }
    }
}
