using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentAcademy.Application.Features.Commands.Lessons.CreateLesson;
using TalentAcademy.Application.Features.Commands.Lessons.DeleteLesson;
using TalentAcademy.Application.Features.Commands.Lessons.UpdateLesson;
using TalentAcademy.Application.Features.Queries.Lessons.GetAllLessonsQueryHandler;
using TalentAcademy.Application.Features.Queries.Lessons.GetLessonQueryHandler;

namespace TalentAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LessonsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllLessonsQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetLessonByIdQueryRequest(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLessonCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLessonCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteLessonCommandRequest(id));
            return NoContent();
        }
    }
}
