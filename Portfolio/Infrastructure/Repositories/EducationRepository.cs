using Domain.Entities;
using Application.Interfaces;
using Application.DTOs;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace Infrastructure.Repositories
{ 
    public class EducationRepository : IEducationRepository
    {
        private readonly IPortfolioDbContext _dbContext;
        public EducationRepository(IPortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EducationDTO>> GetAll()
        {
            var list = await _dbContext.Educations.OrderByDescending(c => c.StartYear).ThenByDescending(c => c.EndYear).ToListAsync();
            return list.Adapt<List<EducationDTO>>();
        }

        public async Task<EducationDTO?> GetById(Guid id)
        {
            var item = await _dbContext.Educations.FindAsync(id);
            return item.Adapt<EducationDTO>();
        }

        public async Task<EducationDTO?> Add(EducationDTO model)
        {
            Education toAdd = model.Adapt<Education>();

            toAdd.Id = Guid.NewGuid();
            toAdd.CreatedAt = DateTime.UtcNow;
            toAdd.LastUpdatedAt = DateTime.UtcNow;

            var result = await _dbContext.Educations.AddAsync(toAdd);
            await _dbContext.SaveChangesAsync();

            return result.Entity.Adapt<EducationDTO>();
        }

        public async Task<EducationDTO?> Update(Guid id, EducationDTO model)
        {
            var toUpdate = await _dbContext.Educations.FindAsync(id);
            if (toUpdate is null) return null;

            toUpdate.Degree = model.Degree;
            toUpdate.FieldOfStudy = model.FieldOfStudy;
            toUpdate.School = model.School;
            toUpdate.StartYear = model.StartYear;
            toUpdate.EndYear = model.EndYear;
            toUpdate.Description = model.Description;
            toUpdate.LastUpdatedAt = DateTime.UtcNow;

            var result = _dbContext.Educations.Update(toUpdate);
            await _dbContext.SaveChangesAsync();

            return result.Entity.Adapt<EducationDTO>();
        }

        public async Task<EducationDTO?> Delete(Guid id)
        {
            var toDelete = await _dbContext.Educations.FindAsync(id);
            if (toDelete is null) return null;

            var result = _dbContext.Educations.Remove(toDelete);
            await _dbContext.SaveChangesAsync();

            return result.Entity.Adapt<EducationDTO>();
        }
    }
}