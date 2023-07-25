using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Domain.DbContexts;
using Domain.Entities;
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
    }
}
