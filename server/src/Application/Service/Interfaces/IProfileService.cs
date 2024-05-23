using Application.DTOs;

namespace Application.Service.Interfaces;

public interface IProfileService
{
    Task<ProfileDto?> Get();
    Task<bool> Update(ProfileDto model);
}