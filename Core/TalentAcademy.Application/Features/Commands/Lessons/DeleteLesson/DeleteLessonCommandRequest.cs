using MediatR;

namespace TalentAcademy.Application.Features.Commands.Lessons.DeleteLesson
{
    public class DeleteLessonCommandRequest : IRequest
    {
        public Guid Id { get; set; }

        public DeleteLessonCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
