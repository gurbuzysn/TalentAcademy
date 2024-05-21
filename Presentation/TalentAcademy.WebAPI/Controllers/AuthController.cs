using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            if (!ModelState.IsValid)
            {
                //Hatalı giriş Loglama işlemleri yapılacak
                // Kullanıcı adı veya şifte hatalı uyarısı verilecek
                //geçerli bir email değilse onun uyarısı verilecek
            }
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
