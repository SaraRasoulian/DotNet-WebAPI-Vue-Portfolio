using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Mapster;

namespace Infrastructure.Services
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
            var list = await _unitOfWork.Education2.GetAll();
            return list.Adapt<List<EducationDTO>>();
        }

        public async Task<EducationDTO> GetById(Guid id)
        {
            var result = await _unitOfWork.Education2.GetById(id);
            return result.Adapt<EducationDTO>();           
        }

        public async Task<EducationDTO> Add(EducationDTO model)
        {
            var EducationEntity = model.Adapt<Education>();
            EducationEntity.Id = Guid.NewGuid();

            var result = await _unitOfWork.Education2.Add(EducationEntity);
            await _unitOfWork.CommitAsync();

            return result.Adapt<EducationDTO>();            
        }

        public async Task<bool> Update(Guid id, EducationDTO model)
        {
            try
            {
                var toUpdate = await _unitOfWork.Education2.GetById(id);
                if (toUpdate is null) return false;

                toUpdate.Degree = model.Degree;
                toUpdate.FieldOfStudy = model.FieldOfStudy;
                toUpdate.School = model.School;
                toUpdate.StartYear = model.StartYear;
                toUpdate.EndYear = model.EndYear;
                toUpdate.Description = model.Description;

                _unitOfWork.Education2.Update(toUpdate);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var toDelete = await _unitOfWork.Education2.GetById(id);
                if (toDelete is null) return false;
                _unitOfWork.Education2.Delete(toDelete);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
