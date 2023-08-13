using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Service
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EducationService(IEducationRepository educationRepository, IUnitOfWork unitOfWork)
        {
            _educationRepository = educationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EducationDTO>> GetAll()
        {
            var result = await _educationRepository.GetAll();
            return result.Adapt<List<EducationDTO>>();
        }

        public async Task<EducationDTO?> GetById(Guid id)
        {
            var result = await _educationRepository.GetById(id);
            return result.Adapt<EducationDTO>();
        }

        public async Task Add(EducationDTO model)
        {
            Education toAdd = model.Adapt<Education>();

            toAdd.Id = Guid.NewGuid();

            await _educationRepository.Add(toAdd);
            await _unitOfWork.SaveChangesAsync();
        }
        public Task<bool> Update(Guid id, EducationDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
