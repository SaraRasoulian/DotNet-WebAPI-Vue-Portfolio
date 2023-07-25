namespace WebAPI.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEducation2Repository Education2 { get; }
        IProfileRepository Profile { get; }
        Task<int> Save();
    }
}
