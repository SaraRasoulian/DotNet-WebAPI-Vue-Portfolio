﻿using Application.DTOs;
using Application.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDto model)
        {
            try
            {
                if (!ModelState.IsValid || model is null) return BadRequest(ModelState);
                var result = await _identityService.Login(model);

                if (result is null) return NoContent();

                return Ok(result);
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