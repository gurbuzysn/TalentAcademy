using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;

        //Navigation Prop.
        public List<Student> Students { get; set; } = new();
        public List<Topic> Topics { get; set; } = new();

    }
}
