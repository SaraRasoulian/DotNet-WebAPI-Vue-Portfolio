using Domain.Interfaces;

namespace Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IProfileRepository Profile { get; }
    IEducationRepository Education { get; }
    IExperienceRepository Experience { get; }
    IMessageRepository Message { get; }
    ISocialLinkRepository SocialLink { get; }
    IUserRepository User { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}