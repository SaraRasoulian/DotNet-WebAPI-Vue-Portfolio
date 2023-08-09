using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Educations_tempController : ControllerBase
    {
        private readonly IEducationRepository_temp _educationsRepository;
        public Educations_tempController(IEducationRepository_temp educationsRepository)
        {
            _educationsRepository = educationsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _educationsRepository.GetAll();
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
                var result = await _educationsRepository.GetById(id);
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

                var result = await _educationsRepository.Add(model);
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
                var result = await _educationsRepository.Update(id, model);
                if (result is null) return StatusCode(StatusCodes.Status400BadRequest);
                return Ok(result);
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
                var result = await _educationsRepository.Delete(id);
                if (result is null) return BadRequest(ModelState);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
