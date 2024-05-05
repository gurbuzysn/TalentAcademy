using MediatR;

namespace TalentAcademy.Application.Features.Commands.Lessons.CreateLesson
{
    public class CreateLessonCommandRequest : IRequest<CreateLessonCommandResponse>
    {
        public string Name { get; set; } = null!;

    }
}
