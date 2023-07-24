using Domain.DbContexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly PortfolioDbContext _dbContext;
        public EducationRepository(PortfolioDbContext dbContext)
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

        public async Task<Education?> Add(Education model)
        {
            model.Id = Guid.NewGuid();
            var result = await _dbContext.Educations.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Education?> Update(Guid id, Education model)
        {
            var toUpdate = await GetById(id);
            if (toUpdate is null) return null;

            toUpdate.Degree = model.Degree;
            toUpdate.FieldOfStudy = model.FieldOfStudy;
            toUpdate.School = model.School;
            toUpdate.StartYear = model.StartYear;
            toUpdate.EndYear = model.EndYear;
            toUpdate.Description = model.Description;
            toUpdate.LastUpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();

            return toUpdate;
        }

        public async Task Delete(Education model)
        {
            _dbContext.Educations.Remove(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}