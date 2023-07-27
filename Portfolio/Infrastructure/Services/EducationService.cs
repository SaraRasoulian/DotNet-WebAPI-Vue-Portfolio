using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Infrastructure.Repositories;

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

            //Temp
            List<EducationDTO> DTOList = new List<EducationDTO>();
            foreach (var item in list)
            {
                var newItem = new EducationDTO
                {
                    Id = item.Id,
                    Degree = item.Degree,
                    FieldOfStudy = item.FieldOfStudy,
                    School = item.School,
                    StartYear = item.StartYear,
                    EndYear = item.EndYear,
                    Description = item.Description,
                    LastUpdatedAt = item.LastUpdatedAt,
                    LastUpdatedBy = item.LastUpdatedBy,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                };

                DTOList.Add(newItem);
            }
            return DTOList;

        }

        public async Task<EducationDTO> GetById(Guid id)
        {
            var item = await _unitOfWork.Education2.GetById(id);

            if (item is null) return null;

            //Temp            
            var newItem = new EducationDTO
            {
                Id = item.Id,
                Degree = item.Degree,
                FieldOfStudy = item.FieldOfStudy,
                School = item.School,
                StartYear = item.StartYear,
                EndYear = item.EndYear,
                Description = item.Description,
            };
            return newItem;
        }

        public async Task<EducationDTO> Add(EducationDTO model)
        {
            //Temp
            var newEntity = new Education
            {
                Degree = model.Degree,
                FieldOfStudy = model.FieldOfStudy,
                School = model.School,
                StartYear = model.StartYear,                    
                EndYear = model.EndYear,
                Description = model.Description,
            };

            var result = await _unitOfWork.Education2.Add(newEntity);
            await _unitOfWork.Save();

            //Temp
            var newDTO = new EducationDTO
            {
                Id = result.Id,
                Degree = result.Degree,
                FieldOfStudy = result.FieldOfStudy,
                School = result.School,
                StartYear = result.StartYear,
                EndYear = result.EndYear,
                Description = result.Description,
                CreatedAt = result.CreatedAt,
                LastUpdatedAt = result.LastUpdatedAt,
            };


            return newDTO;
        }

        public async Task<EducationDTO> Update(Guid id,EducationDTO model)
        {
            var toUpdate = await _unitOfWork.Education2.GetById(id);
            if (toUpdate is null) return null;

            toUpdate.Degree = model.Degree;
            toUpdate.FieldOfStudy = model.FieldOfStudy;
            toUpdate.School = model.School;
            toUpdate.StartYear = model.StartYear;
            toUpdate.EndYear = model.EndYear;
            toUpdate.Description = model.Description;
            toUpdate.LastUpdatedAt = DateTime.UtcNow;

            var result = _unitOfWork.Education2.Update(toUpdate);
            await _unitOfWork.Save();

            //Temp            
            var newItem = new EducationDTO
            {
                Id = result.Id,
                Degree = result.Degree,
                FieldOfStudy = result.FieldOfStudy,
                School = result.School,
                StartYear = result.StartYear,
                EndYear = result.EndYear,
                Description = result.Description,
            };
            return newItem;
        }

        public async Task<EducationDTO> Delete(Guid id)
        {
            var toDelete = await _unitOfWork.Education2.GetById(id);
            if (toDelete is null) return null;
            
            _unitOfWork.Education2.Delete(toDelete);
            await _unitOfWork.Save();

            //Temp            
            var newItem = new EducationDTO
            {
                Id = toDelete.Id,
                Degree = toDelete.Degree,
                FieldOfStudy = toDelete.FieldOfStudy,
                School = toDelete.School,
                StartYear = toDelete.StartYear,
                EndYear = toDelete.EndYear,
                Description = toDelete.Description,
            };
            return newItem;
        }
    }
}
