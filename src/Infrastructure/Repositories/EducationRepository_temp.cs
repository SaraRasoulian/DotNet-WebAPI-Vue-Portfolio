using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class EducationRepository_temp : IEducationRepository_temp
    {
        private readonly IPortfolioDbContext _dbContext;
        public EducationRepository_temp(IPortfolioDbContext dbContext)
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
            if (item == null) return null;
            return item.Adapt<EducationDTO>();
        }

        public async Task<EducationDTO?> Add(EducationDTO model)
        {
            Education toAdd = model.Adapt<Education>();

            toAdd.Id = Guid.NewGuid();

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