using Domain.DbContexts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly PortfolioDbContext _dbContext;
        public EducationRepository(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Education>> Get()
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
            model.CreatedAt = DateTime.UtcNow;
            model.LastUpdatedAt = DateTime.UtcNow;

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

        public async Task<Education?> Delete(Guid id)
        {
            var toDelete = await GetById(id);
            if (toDelete is null) return null;

            _dbContext.Educations.Remove(toDelete);
            await _dbContext.SaveChangesAsync();
            return toDelete;
        }

    }
}
