using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TalentAcademy.Application.Features.Queries.Auth;
using TalentAcademy.Domain.Entities.Identitiy;
using TalentAcademy.Infrastructure.Token;

namespace TalentAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(IMediator mediator, UserManager<IdentityUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }


        //[HttpPost("[action]")]
        //public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        //{
        //    await _mediator.Send(request);
        //    return Ok("", request);
        //}



        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var dto = await _mediator.Send(request);

            if (dto.IsExist)
                return Created("", JwtTokenGenerator.GenerateToken(dto));
            else
                return BadRequest("Kullanıcı adı veya şifre hatalı");
        }


        //[HttpGet("[action]")]
        //public async Task<IActionResult> Logout()
        //{
        //    _userManager
        //    return Ok();
        //}


    }
}
