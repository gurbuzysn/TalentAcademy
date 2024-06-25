using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Dtos.Course;
using TalentAcademy.Application.Dtos.Lesson;
using TalentAcademy.Domain.Entities;

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
