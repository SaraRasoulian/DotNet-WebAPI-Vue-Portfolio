using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationsController : ControllerBase
    {
        private readonly IEducationRepository _educationsRepository;
        public EducationsController(IEducationRepository educationsRepository)
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
        public async Task<IActionResult> Post([FromBody] Education model)
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
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Education model)
        {
            try
            {
                if (model is null || model.Id != id || !ModelState.IsValid) return BadRequest(ModelState);
                var result = await _educationsRepository.Update(id, model);
                if (result is null) return StatusCode(StatusCodes.Status204NoContent);
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
                var toDelete = await _educationsRepository.GetById(id);
                if (toDelete is null) return StatusCode(StatusCodes.Status204NoContent);

                await _educationsRepository.Delete(toDelete);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
