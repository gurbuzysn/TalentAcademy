using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> List(Guid id)
        {
            
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update()
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return NoContent();
        }

    }
}
