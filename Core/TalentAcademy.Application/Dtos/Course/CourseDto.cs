using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Dtos.Student;
using TalentAcademy.Application.Dtos.Topic;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Dtos.Course
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUri { get; set; }

        public List<StudentDto> Students { get; set; } = new();
        public List<TopicDto> Topics { get; set; } = new();
    }
}
