using TalentAcademy.Domain.Enums;

namespace TalentAcademy.Application.Features.Queries.Students.GetAllStudents
{
    public class GetAllStudentsQueryResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}";
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ImageUri { get; set; }
    }
}