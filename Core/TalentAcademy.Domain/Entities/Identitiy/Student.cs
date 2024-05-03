namespace TalentAcademy.Domain.Entities.Identitiy
{
    public class Student : AppUser
    {
        public List<StudentCourse> StudentCourses { get; set; } = new();
    }
}
