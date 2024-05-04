using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentAcademy.Application.Features.Commands.Students.CreateStudent;
using TalentAcademy.Application.Features.Commands.Students.RemoveStudent;
using TalentAcademy.Application.Features.Commands.Students.UpdateStudent;
using TalentAcademy.Application.Features.Queries.Student.GetAllStudent;
using TalentAcademy.Application.Features.Queries.Student.GetByIdStudent;

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
        public async Task<IActionResult> GetAll(GetAllStudentsQueryRequest request)
        {
            if(!ModelState.IsValid) 
                return BadRequest();

            var allStudents = await _mediator.Send(request);
            return Ok(allStudents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(GetStudentByIdQueryRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var selectedStudent = await _mediator.Send(request);
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

        [HttpDelete]
        public async Task<IActionResult> Remove(RemoveStudentCommandRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            await _mediator.Send(request);
            return NoContent();
        }
    }
}
