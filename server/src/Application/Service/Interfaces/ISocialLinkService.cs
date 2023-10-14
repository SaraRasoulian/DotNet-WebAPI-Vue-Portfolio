using Application.DTOs;

namespace Application.Service.Interfaces
{
    public interface ISocialLinkService
    {
        Task<IEnumerable<SocialLinkDto>> GetAll();
        Task<SocialLinkDto?> GetById(Guid id);
        Task<SocialLinkDto> Add(SocialLinkDto model);
        Task<bool> Update(Guid id, SocialLinkDto model);
        Task<bool> Delete(Guid id);
    }
}
