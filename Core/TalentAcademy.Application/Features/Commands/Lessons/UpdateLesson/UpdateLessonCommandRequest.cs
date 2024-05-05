using MediatR;

namespace TalentAcademy.Application.Features.Commands.Lessons.UpdateLesson
{
    public class UpdateLessonCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

    }
}
