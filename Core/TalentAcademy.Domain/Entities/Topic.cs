namespace TalentAcademy.Domain.Entities
{
    public class Topic : BaseEntity
    {
        public string Name { get; set; } = null!;

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public List<Lesson> Lessons { get; set; } = new();
    }
}
