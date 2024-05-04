using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentAcademy.Application.Features.Commands.Students.CreateStudent;
using TalentAcademy.Application.Features.Commands.Students.RemoveStudent;
using TalentAcademy.Application.Features.Commands.Students.UpdateStudent;
using TalentAcademy.Application.Features.Queries.Student.GetAllStudent;
using TalentAcademy.Application.Features.Queries.Student.GetStudentById;

namespace TalentAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var allStudents = await _mediator.Send(new GetAllStudentsQueryRequest());
            return Ok(allStudents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var selectedStudent = await _mediator.Send(new GetStudentByIdQueryRequest(id));
            return Ok(selectedStudent);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommandRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _mediator.Send(request);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentCommandRequest request)
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

            await _mediator.Send(new RemoveStudentCommandRequest(id));
            return NoContent();
        }
    }
}
