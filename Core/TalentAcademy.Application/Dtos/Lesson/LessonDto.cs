using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Dtos.Topic;

namespace TalentAcademy.Application.Dtos.Lesson
{
    public class LessonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string VideoUri { get; set; } = null!;
        public TimeSpan Duration { get; set; }

        public Guid TopicId { get; set; }
        public TopicDto Topic { get; set; } = null!;
    }
}
