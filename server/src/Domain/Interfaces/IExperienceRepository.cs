using Domain.Entities;

namespace Domain.Interfaces;

public interface IExperienceRepository
{
    Task<IEnumerable<Experience>> GetAll();
    Task<Experience?> GetById(Guid id);
    Task<Experience> Add(Experience model);
    void Update(Experience model);
    void Delete(Experience model);
}