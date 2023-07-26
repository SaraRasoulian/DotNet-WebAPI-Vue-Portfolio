using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Educations2Controller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public Educations2Controller(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _unitOfWork.Education2.GetAll();
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
                var result = await _unitOfWork.Education2.GetById(id);
                if (result is null) return StatusCode(StatusCodes.Status204NoContent);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        // Here Use ViewModel instead of DomainModel
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EducationRequest model)
        {
            try
            {
                if (model is null || !ModelState.IsValid) return BadRequest(ModelState);

                var result = await _unitOfWork.Education2.Add(model);
                await _unitOfWork.Save();

                if (result is null) return StatusCode(StatusCodes.Status204NoContent, result);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] EducationRequest model)
        {
            try
            {
                if (model is null || model.Id != id || !ModelState.IsValid) return BadRequest(ModelState);

                var toUpdate = await _unitOfWork.Education2.GetById(id);
                if (toUpdate is null) return BadRequest(ModelState);

                //To Do : create a service layer maybe? this code shouln't be here
                toUpdate.Degree = model.Degree;
                toUpdate.FieldOfStudy = model.FieldOfStudy;
                toUpdate.School = model.School;
                toUpdate.StartYear = model.StartYear;
                toUpdate.EndYear = model.EndYear;
                toUpdate.Description = model.Description;
                toUpdate.LastUpdatedAt = DateTime.UtcNow;

                var result = _unitOfWork.Education2.Update(toUpdate);
                await _unitOfWork.Save();

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
                var toDelete = await _unitOfWork.Education2.GetById(id);
                if (toDelete is null) return StatusCode(StatusCodes.Status204NoContent);

                _unitOfWork.Education2.Delete(toDelete);
                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
