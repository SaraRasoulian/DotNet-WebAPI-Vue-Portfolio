using Application.DTOs;
using Domain.Entities;

namespace Application.Service.Interfaces
{
    public interface IIdentityService
    {
        Task<string?> Login(UserLoginDto userLogin);
        Task<bool> ChangePassword(PasswordDto model, string userName);
        string GenerateToken(User user);
    }
}