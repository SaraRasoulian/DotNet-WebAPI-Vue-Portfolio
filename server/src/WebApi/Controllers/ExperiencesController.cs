using Application.DTOs;
using Application.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/experiences")]
[ApiController]
public class ExperiencesController : ControllerBase
{
    private readonly IExperienceService _experienceService;
    public ExperiencesController(IExperienceService experienceService)
    {
        _experienceService = experienceService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _experienceService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await _experienceService.GetById(id);
        if (result is null) return NoContent();
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] ExperienceDto dto)
    {
        if (!ModelState.IsValid || dto is null) return BadRequest(ModelState);
        var result = await _experienceService.Add(dto);
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] ExperienceDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _experienceService.Update(id, dto);
        if (!result) return BadRequest();
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _experienceService.Delete(id);
        if (!result) return BadRequest();
        return Ok();
    }
}
