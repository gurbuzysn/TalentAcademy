using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentAcademy.Application.Features.Queries.Courses.GetAllCourses;

namespace TalentAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var allCourses = await _mediator.Send(new GetAllCoursesQueryRequest());
            return Ok(allCourses);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get()
        //{
        //    return Ok();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Created(CreateCourseCommandRequest request)
        //{
        //    return Created("");
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update(UpdateCourseCommandRequest request)
        //{
        //    return Ok();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Remove(Guid id)
        //{
        //    return Ok();
        //}
    }
}
