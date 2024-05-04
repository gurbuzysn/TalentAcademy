using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TalentAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Created(CreateCourseCommandRequest request)
        {
            return Created("");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseCommandRequest request)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Ok();
        }
    }
}
