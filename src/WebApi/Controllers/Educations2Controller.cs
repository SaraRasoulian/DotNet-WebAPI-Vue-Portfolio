using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Educations2Controller : ControllerBase
    {
        private readonly IEducationService _educationService;
        public Educations2Controller(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _educationService.GetAll();
                if (result is null) return StatusCode(StatusCodes.Status204NoContent);
                return Ok(result);
            }
            catch (Exception)
            {
                // To Do: log the exceptions
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var result = await _educationService.GetById(id);
                if (result is null) return StatusCode(StatusCodes.Status204NoContent);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EducationDTO model)
        {
            try
            {
                if (model is null || !ModelState.IsValid) return BadRequest(ModelState);

                var result = await _educationService.Add(model);
                if (result is null) return StatusCode(StatusCodes.Status204NoContent, result);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] EducationDTO model)
        {
            try
            {
                if (model is null || model.Id != id || !ModelState.IsValid) return BadRequest(ModelState);

                bool isOk = await _educationService.Update(id, model);
                if (!isOk) return StatusCode(StatusCodes.Status400BadRequest);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var isOk = await _educationService.Delete(id);
                if (!isOk) return StatusCode(StatusCodes.Status400BadRequest);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
