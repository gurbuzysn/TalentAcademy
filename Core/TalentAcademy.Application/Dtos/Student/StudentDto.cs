using TalentAcademy.Application.Dtos.Course;
using TalentAcademy.Domain.Enums;

namespace TalentAcademy.Application.Dtos.Student
{
    public class StudentDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ImageUri { get; set; }
        public List<CourseDto> Courses { get; set; } = new();

    }
}
