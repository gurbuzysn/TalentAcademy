using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentAcademy.Application.Features.Commands.Courses.CreateCourse;
using TalentAcademy.Application.Features.Commands.Courses.RemoveCourse;
using TalentAcademy.Application.Features.Commands.Courses.UpdateCourse;
using TalentAcademy.Application.Features.Queries.Courses.GetAllCourses;
using TalentAcademy.Application.Features.Queries.Courses.GetCourseById;

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
            if (!ModelState.IsValid)
                return BadRequest();

            var allCourses = await _mediator.Send(new GetAllCoursesQueryRequest());
            return Ok(allCourses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var course = await _mediator.Send(new GetCourseByIdQueryRequest(id));
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Created(CreateCourseCommandRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(request);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseCommandRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _mediator.Send(new RemoveCourseCommandRequest(id));
            return NoContent();
        }
    }
}
