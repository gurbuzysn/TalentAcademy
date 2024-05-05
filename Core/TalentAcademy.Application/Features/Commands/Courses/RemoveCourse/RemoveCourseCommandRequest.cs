using MediatR;

namespace TalentAcademy.Application.Features.Commands.Courses.RemoveCourse
{
    public class RemoveCourseCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public RemoveCourseCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
