using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> Get(string userName, string password);
        Task<User?> GetByUserName(string userName);
        void Update(User user);
    }
}