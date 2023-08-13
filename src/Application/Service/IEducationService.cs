using Application.DTOs;

namespace Application.Service
{
    public interface IEducationService
    {
        Task<IEnumerable<EducationDTO>> GetAll();
        Task<EducationDTO?> GetById(Guid id);
        Task Add(EducationDTO model);
        Task<bool> Update(Guid id ,EducationDTO model);
        Task<bool> Delete(Guid id);
    }
}
