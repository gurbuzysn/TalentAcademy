using TalentAcademy.Application.Dtos;

namespace TalentAcademy.Application.Features.Queries.Auth
{
    public class CheckUserQueryResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? ImageUri { get; set; } = null!;
        public TokenResponseDto Token { get; set; } = null!;
    }
}