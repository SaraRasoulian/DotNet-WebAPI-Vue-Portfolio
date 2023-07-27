using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data.DbContexts;
namespace Infrastructure.Repositories
{
    public class Education2Repository : GenericRepository<Education>, IEducation2Repository
    {
        public Education2Repository(PortfolioDbContext context) : base(context)
        {
            
        }
    }
}
