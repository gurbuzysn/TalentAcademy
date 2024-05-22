using MediatR;

namespace TalentAcademy.Application.Features.Queries.Auth
{
    public class CheckUserQueryRequest : IRequest<CheckUserQueryResponse>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
