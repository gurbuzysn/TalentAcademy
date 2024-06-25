using TalentAcademy.Domain.Entities.Identitiy;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Queries.Courses.GetAllCourses
{
    public class GetAllCoursesQueryResponse
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string? ImageUri { get; set; }

        public List<Student> Students { get; set; } = new();
        public List<Topic> Topics { get; set; } = new();
    }
}