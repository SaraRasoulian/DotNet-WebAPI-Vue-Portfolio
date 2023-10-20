using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> Get(string userName, string password);
    }
}