using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Queries.Courses.GetAllCourses
{
    public class GetAllCoursesQueryResponse
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;

        //Navigation Prop.
        public List<Topic> Topics { get; set; } = new();
        public List<StudentCourse> StudentCourses { get; set; } = new();
    }
}