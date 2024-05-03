using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            var allStudents = await _mediator.Send(request);
            return Ok(allStudents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(GetStudentByIdQueryRequest request)
        {
            var selectedStudent = await _mediator.Send(request);
            return Ok(selectedStudent);
        }




    }
}
