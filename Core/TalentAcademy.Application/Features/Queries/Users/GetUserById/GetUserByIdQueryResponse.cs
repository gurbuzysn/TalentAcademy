namespace TalentAcademy.Application.Features.Queries.Users.GetUserById
{
    public class GetUserByIdQueryResponse
    {
        public string FullName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}