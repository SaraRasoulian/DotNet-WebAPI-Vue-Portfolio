using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Domain.DbContexts;
using Domain.Entities;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationsController : ControllerBase
    {
        private readonly PortfolioDbContext _dbContext;
        public EducationsController(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _dbContext.Educations.OrderByDescending(c => c.StartYear).ThenByDescending(c => c.EndYear).ToListAsync();
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
                var result = await _dbContext.Educations.FindAsync(id);
                if (result is null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Education value)
        {
            try
            {
                if (value is null || !ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                value.Id = Guid.NewGuid();
                value.CreatedAt = DateTime.UtcNow;
                value.LastUpdatedAt = DateTime.UtcNow;

                var result = await _dbContext.Educations.AddAsync(value);
                await _dbContext.SaveChangesAsync();
                return Ok(result.Entity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Education value)
        {
            try
            {
                if (value is null || !ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != value.Id)
                {
                    return BadRequest(value);
                }

                var toUpdate = await _dbContext.Educations.FindAsync(id);
                if (toUpdate is null)
                {
                    return BadRequest(toUpdate);
                }

                toUpdate.Degree = value.Degree;
                toUpdate.FieldOfStudy = value.FieldOfStudy;
                toUpdate.School = value.School;
                toUpdate.StartYear = value.StartYear;
                toUpdate.EndYear = value.EndYear;
                toUpdate.Description = value.Description;
                toUpdate.LastUpdatedAt = DateTime.UtcNow;

                await _dbContext.SaveChangesAsync();

                return Ok(toUpdate);
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
                var toDelete = await _dbContext.Educations.FindAsync(id);
                if (toDelete is null)
                {
                    return BadRequest(toDelete);
                }
                _dbContext.Educations.Remove(toDelete);
                await _dbContext.SaveChangesAsync();
                return Ok(toDelete);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
