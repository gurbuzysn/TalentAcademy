namespace TalentAcademy.Domain.Entities.Identitiy
{
    public class Student : AppUser
    {
        public List<Course> Courses { get; set; } = new();
    }
}
