using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Domain.Entities.Common;

namespace TalentAcademy.Domain.Entities
{
    public class Lesson : BaseEntity
    {
        public string Name { get; set; } = null!;
        public TimeSpan Duration { get; set; }
        public string VideoUri { get; set; } = null!;

        public Guid TopicId { get; set; }
        public Topic Topic { get; set; } = null!;
    }
}
