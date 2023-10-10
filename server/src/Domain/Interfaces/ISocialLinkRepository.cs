using Domain.Entities;
namespace Domain.Interfaces
{
    public interface ISocialLinkRepository
    {
        Task<IEnumerable<SocialLink>> GetAll();
        Task<SocialLink?> GetById(Guid id);
        Task<SocialLink> Add(SocialLink model);
        void Update(SocialLink model);
        void Delete(SocialLink model);
    }
}