using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly IPortfolioDbContext _dbContext;
        public EducationRepository(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Education>> GetAll()
        {
            return await _dbContext.Educations.OrderByDescending(c => c.StartYear).ThenByDescending(c => c.EndYear).ToListAsync();
        }

        public async Task<Education?> GetById(Guid id)
        {
            return await _dbContext.Educations.FindAsync(id);
        }

        public async Task Add(Education model)
        {
            await _dbContext.Educations.AddAsync(model);
        }

        public void Update(Education model)
        {
            _dbContext.Educations.Update(model);
        }

        public void Delete(Education model)
        {
            _dbContext.Educations.Remove(model);
        }
    }
}
