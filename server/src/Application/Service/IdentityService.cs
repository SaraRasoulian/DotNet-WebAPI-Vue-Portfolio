using Application.DTOs;
using Application.Interfaces;
using Application.Service.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Service;

public class IdentityService : IIdentityService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _config;
    public IdentityService(IUnitOfWork unitOfWork, IConfiguration config)
    {
        _unitOfWork = unitOfWork;
        _config = config;
    }

    public async Task<string?> Login(UserLoginDto userLogin)
    {
        User? user = await _unitOfWork.User.Get(userLogin.UserName, userLogin.Password);

        if (user == null) return null;

        return GenerateToken(user);
    }

    public async Task<bool> ChangePassword(PasswordDto dto, string userName)
    {
        if (dto.newPassword != dto.confirmNewPassword) return false;
        
        User? user = await _unitOfWork.User.GetByUserName(userName);
        
        if (user == null || user.Password != dto.currentPassword) return false;
        
        user.Password = dto.newPassword;

        _unitOfWork.User.Update(user);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }        

    public string GenerateToken(User user)
    {
        var issuer = _config["JwtSettings:Issuer"];
        var audience = _config["JwtSettings:Audience"];
        var key = Encoding.ASCII.GetBytes(_config["JwtSettings:Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim("Id", Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti,
            Guid.NewGuid().ToString())
         }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }
}
