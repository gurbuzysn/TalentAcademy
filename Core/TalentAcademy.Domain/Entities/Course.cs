using TalentAcademy.Domain.Entities.Common;

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
