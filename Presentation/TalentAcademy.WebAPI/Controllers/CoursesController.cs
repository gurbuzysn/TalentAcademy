using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentAcademy.Application.Features.Commands.Courses;
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

        [HttpGet("{CourseName}")]
        public async Task<IActionResult> GetByCourseName(string CourseName)
        {
            var course = await _mediator.Send(new GetByCourseNameQueryRequest(CourseName));
            return Ok(course);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid courseId)
        {
            var course = await _mediator.Send(new GetCourseByIdQueryRequest(courseId));
            return Ok(course);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }
    }
}
