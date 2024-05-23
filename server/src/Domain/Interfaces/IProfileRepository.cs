using Domain.Entities;

namespace Domain.Interfaces;

public interface IProfileRepository
{
    Task<Profile?> Get();
    void Update(Profile model);
}