using Application.DTOs;
using Application.Interfaces;
using Application.Service.Interfaces;
using Domain.Entities;
using Mapster;

namespace Application.Service;

public class ExperienceService : IExperienceService
{
    private readonly IUnitOfWork _unitOfWork;
    public ExperienceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ExperienceDto>> GetAll()
    {
        var result = await _unitOfWork.Experience.GetAll();
        return result.Adapt<List<ExperienceDto>>();
    }

    public async Task<ExperienceDto?> GetById(Guid id)
    {
        var result = await _unitOfWork.Experience.GetById(id);
        return result?.Adapt<ExperienceDto>();
    }

    public async Task<ExperienceDto> Add(ExperienceDto model)
    {
        Experience toAdd = model.Adapt<Experience>();
        toAdd.Id = Guid.NewGuid();
        var result = await _unitOfWork.Experience.Add(toAdd);
        await _unitOfWork.SaveChangesAsync();
        return result.Adapt<ExperienceDto>();
    }

    public async Task<bool> Update(Guid id, ExperienceDto model)
    {
        if (model is null || model.Id != id) return false;

        var toUpdate = await _unitOfWork.Experience.GetById(id);
        if (toUpdate is null) return false;

        toUpdate = model.Adapt<Experience>();

        _unitOfWork.Experience.Update(toUpdate);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(Guid id)
    {
        var toDelete = await _unitOfWork.Experience.GetById(id);
        if (toDelete is null) return false;

        _unitOfWork.Experience.Delete(toDelete);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
