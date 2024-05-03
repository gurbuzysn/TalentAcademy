using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Domain.Entities.Common;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;

        //Navigation Prop.
        public List<Topic> Topics { get; set; } = new();
        public List<StudentCourse> StudentCourses { get; set; } = new();

    }
}
