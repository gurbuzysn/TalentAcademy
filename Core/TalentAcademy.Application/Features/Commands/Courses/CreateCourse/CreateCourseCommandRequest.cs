using MediatR;

namespace TalentAcademy.Application.Features.Commands.Courses.CreateCourse
{
    public class CreateCourseCommandRequest : IRequest<CreateCourseCommandResponse>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
    }
}
