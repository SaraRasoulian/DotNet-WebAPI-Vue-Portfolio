using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProfileRepository Profile { get; }
        IEducationRepository Education { get; }
        IMessageRepository Message { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}