using Application.DTOs;

namespace Application.Service.Interfaces;

public interface IEducationService
{
    Task<IEnumerable<EducationDto>> GetAll();
    Task<EducationDto?> GetById(Guid id);
    Task<EducationDto> Add(EducationDto model);
    Task<bool> Update(Guid id, EducationDto model);
    Task<bool> Delete(Guid id);
}
