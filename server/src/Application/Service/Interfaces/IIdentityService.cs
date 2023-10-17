using Application.DTOs;
using Domain.Entities;

namespace Application.Service.Interfaces
{
    public interface IIdentityService
    {
        Task<string> Login(UserLoginDto userLogin);
        string GenerateToken(User user);
    }
}