using TalentAcademy.Domain.Enums;

namespace TalentAcademy.Application.Features.Queries.Student.GetAllStudent
{
    public class GetAllStudentsQueryResponse
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}";
        public Gender Gender { get; set; }
        public DateTime BirthOfDate { get; set; }
        public string? Image { get; set; }
    }
}