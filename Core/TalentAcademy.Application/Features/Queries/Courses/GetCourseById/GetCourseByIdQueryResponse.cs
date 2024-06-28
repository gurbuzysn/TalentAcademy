using TalentAcademy.Application.Dtos.Student;
using TalentAcademy.Application.Dtos.Topic;

namespace TalentAcademy.Application.Features.Queries.Courses.GetCourseById
{
    public class GetCourseByIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string? ImageUri { get; set; }

        public List<StudentDto> Students { get; set; } = new();
        public List<TopicDto> Topics { get; set; } = new();
    }
}