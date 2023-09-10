using Application.DTOs;
using Application.Interfaces;
using Application.Service.Interfaces;
using Domain.Entities;
using Mapster;

namespace Application.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProfileDto?> Get()
        {
            var result = await _unitOfWork.Profile.Get();
            return result?.Adapt<ProfileDto>();
        }

        public async Task<bool> Update(ProfileDto model)
        {
            if (model is null) return false;

            var toUpdate = await _unitOfWork.Profile.Get();
            if (toUpdate is null) return false;

            if (toUpdate.Id != model.Id) return false;

            toUpdate = model.Adapt<Profile>();

            _unitOfWork.Profile.Update(toUpdate);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
