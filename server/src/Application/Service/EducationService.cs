using Application.DTOs;
using Application.Interfaces;
using Application.Service.Interfaces;
using Domain.Entities;
using Mapster;

namespace Application.Service
{
    public class EducationService : IEducationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EducationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EducationDto>> GetAll()
        {
            var result = await _unitOfWork.Education.GetAll();
            return result.Adapt<List<EducationDto>>();
        }

        public async Task<EducationDto?> GetById(Guid id)
        {
            var result = await _unitOfWork.Education.GetById(id);
            return result?.Adapt<EducationDto>();
        }

        public async Task<EducationDto> Add(EducationDto model)
        {
            Education toAdd = model.Adapt<Education>();
            toAdd.Id = Guid.NewGuid();
            var result = await _unitOfWork.Education.Add(toAdd);
            await _unitOfWork.SaveChangesAsync();
            return result.Adapt<EducationDto>();
        }

        public async Task<bool> Update(Guid id, EducationDto model)
        {
            if (model is null || model.Id != id) return false;

            var toUpdate = await _unitOfWork.Education.GetById(id);
            if (toUpdate is null) return false;

            toUpdate = model.Adapt<Education>();

            _unitOfWork.Education.Update(toUpdate);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var toDelete = await _unitOfWork.Education.GetById(id);
            if (toDelete is null) return false;

            _unitOfWork.Education.Delete(toDelete);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
