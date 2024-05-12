using Application.DTOs;
using Application.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/social-links")]
    [ApiController]
    public class SocialLinksController : ControllerBase
    {
        private readonly ISocialLinkService _socialLinkService;
        public SocialLinksController(ISocialLinkService socialLinkService)
        {
            _socialLinkService = socialLinkService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _socialLinkService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _socialLinkService.GetById(id);
            if (result is null) return NoContent();
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] SocialLinkDto dto)
        {
            if (!ModelState.IsValid || dto is null) return BadRequest(ModelState);
            var result = await _socialLinkService.Add(dto);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] SocialLinkDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _socialLinkService.Update(id, dto);
            if (!result) return BadRequest();
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _socialLinkService.Delete(id);
            if (!result) return BadRequest();
            return Ok();
        }
    }
}
