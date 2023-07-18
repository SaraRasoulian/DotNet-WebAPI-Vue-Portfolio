using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/educations")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        // GET: api/educations
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/educations/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/educations
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/educations/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/educations/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
