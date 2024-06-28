namespace TalentAcademy.Application.Features.Queries.Courses.GetByCourseName
{
    public class GetByCourseNameQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string? ImageUri { get; set; }
    }
}