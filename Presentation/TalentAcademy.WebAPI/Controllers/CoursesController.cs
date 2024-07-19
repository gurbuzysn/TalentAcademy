using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentAcademy.Application.Features.Commands.Courses;
using TalentAcademy.Application.Features.Commands.Courses.DeleteCourse;
using TalentAcademy.Application.Features.Queries.Courses.GetAllCourses;
using TalentAcademy.Application.Features.Queries.Courses.GetByCourseName;
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
        public async Task<IActionResult> GetAllCourse()
        {
            var allCourse = await _mediator.Send(new GetAllCoursesQueryRequest());
            return Ok(allCourse);
        }

        [HttpGet("byname/{CourseName}")]
        public async Task<IActionResult> GetByCourseName(string CourseName)
        {
            var course = await _mediator.Send(new GetByCourseNameQueryRequest(CourseName));
            return Ok(course);
        }

        [HttpGet("byid/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var course = await _mediator.Send(new GetCourseByIdQueryRequest(id));
            return Ok(course);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = _mediator.Send(new DeleteCourseCommandRequest(id));

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> AddTopicToCourse( )
        {
            return Created();
        }

    }
}
