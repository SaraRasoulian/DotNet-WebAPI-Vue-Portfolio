using Application.DTOs;
using Application.Interfaces;
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

        public async Task<IEnumerable<EducationDTO>> GetAll()
        {
            var result = await _unitOfWork.Education.GetAll();
            return result.Adapt<List<EducationDTO>>();
        }

        public async Task<EducationDTO?> GetById(Guid id)
        {
            var result = await _unitOfWork.Education.GetById(id);
            return result?.Adapt<EducationDTO>();
        }

        public async Task<bool> Add(EducationDTO model)
        {
            if (model is null) return false;
            Education toAdd = model.Adapt<Education>();

            toAdd.Id = Guid.NewGuid();

            await _unitOfWork.Education.Add(toAdd);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Update(Guid id, EducationDTO model)
        {
            if (model is null || model.Id != id) return false;

            var toUpdate = await _unitOfWork.Education.GetById(id);
            if (toUpdate is null) return false;

            toUpdate.Degree = model.Degree;
            toUpdate.FieldOfStudy = model.FieldOfStudy;
            toUpdate.School = model.School;
            toUpdate.StartYear = model.StartYear;
            toUpdate.EndYear = model.EndYear;
            toUpdate.Description = model.Description;

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
