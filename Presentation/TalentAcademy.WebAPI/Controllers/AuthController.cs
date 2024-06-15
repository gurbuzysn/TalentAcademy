using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TalentAcademy.Application.Features.Queries.Auth;
using TalentAcademy.Infrastructure.Token;

namespace TalentAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AuthController(IMediator mediator, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _mediator = mediator;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            if (!ModelState.IsValid)
            {
                //Hatalı giriş Loglama işlemleri yapılacak
                // Kullanıcı adı veya şifte hatalı uyarısı verilecek
                //geçerli bir email değilse onun uyarısı verilecek
            }
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                var checkUserQueryResponse = _mapper.Map<CheckUserQueryResponse>(response.Result);
                var token = JwtTokenGenerator.GenerateToken(checkUserQueryResponse);

                checkUserQueryResponse.Token = token;
                response.Result = checkUserQueryResponse;

                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
