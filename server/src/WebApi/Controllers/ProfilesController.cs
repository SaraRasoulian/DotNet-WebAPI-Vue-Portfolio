using Application.DTOs;
using Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
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
            try
            {
                var result = await _ProfileService.Get();
                return Ok(result);
            }
            catch (Exception)
            {
                // To Do: log the exceptions
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProfileDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var result = await _ProfileService.Update(model);
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
