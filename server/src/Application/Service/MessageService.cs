using Application.DTOs;
using Application.Extentions;
using Application.Interfaces;
using Application.Service.Interfaces;
using Domain.Entities;
using Mapster;

namespace Application.Service
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MessageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MessageDto>> GetAll()
        {
            var result = await _unitOfWork.Message.GetAll();
            return result.Adapt<List<MessageDto>>();
        }

        public async Task<MessageDto?> GetById(Guid id)
        {
            var result = await _unitOfWork.Message.GetById(id);
            if (result is null) return null;

            MessageDto dto = result.Adapt<MessageDto>();

            dto.SentAt = result.SentAt.ToString("dd MMMM yyyy");
            dto.TimeAgo = result.SentAt.TimeAgo();
            return dto;
        }

        public async Task<MessageDto> Add(MessageDto model)
        {
            Message toAdd = model.Adapt<Message>();
            toAdd.Id = Guid.NewGuid();
            toAdd.SentAt = DateTime.UtcNow;
            var result = await _unitOfWork.Message.Add(toAdd);
            await _unitOfWork.SaveChangesAsync();
            return result.Adapt<MessageDto>();
        }

        public async Task<bool> Delete(Guid id)
        {
            var toDelete = await _unitOfWork.Message.GetById(id);
            if (toDelete is null) return false;

            _unitOfWork.Message.Delete(toDelete);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
