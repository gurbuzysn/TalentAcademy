using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentAcademy.Application.Features.Commands.Topics.CreateTopic;
using TalentAcademy.Application.Features.Commands.Topics.DeleteTopic;
using TalentAcademy.Application.Features.Commands.Topics.UpdateTopic;
using TalentAcademy.Application.Features.Queries.Topics.GetAllTopics;
using TalentAcademy.Application.Features.Queries.Topics.GetTopicById;

namespace TalentAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TopicsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllTopicsQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> List(Guid id)
        {
            var result = await _mediator.Send(new GetTopicByIdQueryRequest(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTopicCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTopicCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTopicCommandRequest(id));
            return NoContent();
        }

    }
}
