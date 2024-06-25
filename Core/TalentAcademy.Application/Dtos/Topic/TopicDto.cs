using TalentAcademy.Application.Dtos.Course;
using TalentAcademy.Application.Dtos.Lesson;

namespace TalentAcademy.Application.Dtos.Topic
{
    public class TopicDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid CourseId { get; set; }
        public CourseDto Course { get; set; } = null!;
        public List<LessonDto> Lessons { get; set; } = new();
    }
}
