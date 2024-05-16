using Application.DTOs;
using Application.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/educations")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly IEducationService _educationService;
        public EducationsController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _educationService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _educationService.GetById(id);
            if (result is null) return NoContent();
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] EducationDto dto)
        {
            if (!ModelState.IsValid || dto is null) return BadRequest(ModelState);
            var result = await _educationService.Add(dto);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] EducationDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _educationService.Update(id, dto);
            if (!result) return BadRequest();
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _educationService.Delete(id);
            if (!result) return BadRequest();
            return Ok();
        }
    }
}
