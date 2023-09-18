using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetAll();
        Task<int> GetNumberOfUnread();
        Task<Message?> GetById(Guid id);
        Task<Message> Add(Message model);
        void Update(Message model);
        void Delete(Message model);
    }
}