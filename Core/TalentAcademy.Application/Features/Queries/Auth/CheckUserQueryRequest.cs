using MediatR;

namespace TalentAcademy.Application.Features.Queries.Auth
{
    public class CheckUserQueryRequest : IRequest<GeneralResponse>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
