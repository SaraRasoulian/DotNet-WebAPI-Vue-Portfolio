using Application.DTOs;

namespace Application.Services
{
    public interface IEducationService
    {
        Task<IEnumerable<EducationDTO>> GetAll();

        Task<EducationDTO> GetById(Guid id);

        Task<EducationDTO> Add(EducationDTO model);

        Task<EducationDTO> Update(Guid id, EducationDTO model);

        Task<EducationDTO> Delete(Guid id);
    }
}
