using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentAcademy.Application.Features.Commands.Courses;
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
        public async Task<IActionResult> GetAllCourse()
        {
            var allCourse = await _mediator.Send(new GetAllCoursesQueryRequest());
            return Ok(allCourse);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }
    }
}
