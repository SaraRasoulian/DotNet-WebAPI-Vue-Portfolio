using Application.DTOs;
using Application.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
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
            try
            {
                var result = await _socialLinkService.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var result = await _socialLinkService.GetById(id);
                if (result is null) return NoContent();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] SocialLinkDto dto)
        {
            try
            {
                if (!ModelState.IsValid || dto is null) return BadRequest(ModelState);
                var result = await _socialLinkService.Add(dto);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] SocialLinkDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = await _socialLinkService.Update(id, dto);
                if (!result) return BadRequest();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var result = await _socialLinkService.Delete(id);
                if (!result) return BadRequest();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
