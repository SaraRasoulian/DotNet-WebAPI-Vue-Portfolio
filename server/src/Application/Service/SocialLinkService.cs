using Application.DTOs;
using Application.Interfaces;
using Application.Service.Interfaces;
using Domain.Entities;
using Mapster;

namespace Application.Service;

public class SocialLinkService : ISocialLinkService
{
    private readonly IUnitOfWork _unitOfWork;
    public SocialLinkService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<SocialLinkDto>> GetAll()
    {
        var result = await _unitOfWork.SocialLink.GetAll();
        return result.Adapt<List<SocialLinkDto>>();
    }

    public async Task<SocialLinkDto?> GetById(Guid id)
    {
        var result = await _unitOfWork.SocialLink.GetById(id);
        return result?.Adapt<SocialLinkDto>();
    }

    public async Task<SocialLinkDto> Add(SocialLinkDto model)
    {
        SocialLink toAdd = model.Adapt<SocialLink>();
        toAdd.Id = Guid.NewGuid();
        var result = await _unitOfWork.SocialLink.Add(toAdd);
        await _unitOfWork.SaveChangesAsync();
        return result.Adapt<SocialLinkDto>();
    }

    public async Task<bool> Update(Guid id, SocialLinkDto model)
    {
        if (model is null || model.Id != id) return false;

        var toUpdate = await _unitOfWork.SocialLink.GetById(id);
        if (toUpdate is null) return false;

        toUpdate = model.Adapt<SocialLink>();

        _unitOfWork.SocialLink.Update(toUpdate);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(Guid id)
    {
        var toDelete = await _unitOfWork.SocialLink.GetById(id);
        if (toDelete is null) return false;

        _unitOfWork.SocialLink.Delete(toDelete);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
