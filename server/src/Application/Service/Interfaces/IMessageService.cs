using Application.DTOs;

namespace Application.Service.Interfaces;

public interface IMessageService
{
    Task<IEnumerable<MessageDto>> GetAll();
    Task<MessageDto?> GetById(Guid id);
    Task<MessageDto> Add(MessageDto model);
    Task<bool> Delete(Guid id);
    Task<int> GetNumberOfUnread();
    Task<bool> MarkAsRead(Guid id);
}
