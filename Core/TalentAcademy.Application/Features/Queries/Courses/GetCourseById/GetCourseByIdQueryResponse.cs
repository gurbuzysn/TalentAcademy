using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Queries.Courses.GetCourseById
{
    public class GetCourseByIdQueryResponse
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;

        //Navigation Prop.
        public List<Topic> Topics { get; set; } = new();
    }
}