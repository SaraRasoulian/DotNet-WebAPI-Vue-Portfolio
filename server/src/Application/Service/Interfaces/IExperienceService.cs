using Application.DTOs;

namespace Application.Service.Interfaces;

public interface IExperienceService
{
    Task<IEnumerable<ExperienceDto>> GetAll();
    Task<ExperienceDto?> GetById(Guid id);
    Task<ExperienceDto> Add(ExperienceDto model);
    Task<bool> Update(Guid id, ExperienceDto model);
    Task<bool> Delete(Guid id);
}
