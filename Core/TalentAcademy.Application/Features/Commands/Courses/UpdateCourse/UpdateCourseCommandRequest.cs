using MediatR;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Commands.Courses.UpdateCourse
{
    public class UpdateCourseCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;

        public DateTime UpdatedDate { get; set; }


        public List<Topic> Topics { get; set; } = new();
        public List<StudentCourse> StudentCourses { get; set; } = new();
    }
}
