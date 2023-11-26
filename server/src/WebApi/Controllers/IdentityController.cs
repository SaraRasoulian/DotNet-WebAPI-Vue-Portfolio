using Application.DTOs;
using Application.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDto dto)
        {
            try
            {
                if (!ModelState.IsValid || dto is null) return BadRequest(ModelState);
                var result = await _identityService.Login(dto);

                if (result is null) return NoContent();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("change-password")]
        [Authorize]
        public async Task<ActionResult> ChangePassword([FromBody] PasswordDto dto)
        {
            try
            {
                if (!ModelState.IsValid || dto is null) return BadRequest(ModelState);

                string userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var result = await _identityService.ChangePassword(dto, userName);
                if (!result) return BadRequest();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("validate-token")]
        [Authorize]
        public IActionResult ValidateToken()
        {
            // If the request reaches this point, it means the token is valid
            return Ok();
        }
    }
}
