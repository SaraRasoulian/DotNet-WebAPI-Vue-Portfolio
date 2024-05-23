using Application.DTOs;
using Application.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers;

[Route("api/profiles")]
[ApiController]
public class ProfilesController : ControllerBase
{
    private readonly IProfileService _ProfileService;
    public ProfilesController(IProfileService ProfileService)
    {
        _ProfileService = ProfileService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _ProfileService.Get();
        return Ok(result);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Put([FromBody] ProfileDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _ProfileService.Update(dto);
        if (!result) return BadRequest();
        return Ok();
    }

}
