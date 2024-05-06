using MediatR;
using Microsoft.AspNetCore.Mvc;
using TalentAcademy.Application.Features.Queries.Auth;

namespace TalentAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        //[HttpPost("[action]")]
        //public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        //{
        //    await _mediator.Send(request);
        //    return Ok("", request);
        //}



        [HttpPost("[action]")]
        public async IActionResult Login(CheckUserQueryRequest request)
        {
            var dto = await _mediator.Send(request);

            if (dto.IsExist)
                return Created("", JwtTokenGenerator.GenerateToken(dto));
            else
                return BadRequest("Kullanıcı adı veya şifre hatalı");
        }
    }
}
