﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentAcademy.Application.Features.Commands.Students.CreateStudent;
using TalentAcademy.Application.Features.Commands.Students.DeleteStudent;
using TalentAcademy.Application.Features.Queries.Students.GetAllStudents;

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

        
        [ResponseCache(Duration = 10)]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllStudentsQueryRequest());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteStudentCommandRequest(id));
            return Ok(response);
        }


    }
}
