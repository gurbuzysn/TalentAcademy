using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TalentAcademy.Application.Features.Queries.Users.GetUserById;

namespace TalentAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> GetUser([FromBody] Guid id)
        {
            var result = await _mediator.Send(new GetUserByIdQueryRequest(id));


            var jsonData = JsonSerializer.Serialize(result);

            return Ok(jsonData);

        }
    }
}
