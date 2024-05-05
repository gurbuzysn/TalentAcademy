using MediatR;

namespace TalentAcademy.Application.Features.Commands.Lessons.CreateLesson
{
    public class CreateLessonCommandRequest : IRequest<CreateLessonCommandResponse>
    {
        public string Name { get; set; } = null!;
        public string VideoUri { get; set; } = null!;
        public TimeSpan Duration { get; set; }

        public Guid TopicId { get; set; }


    }
}
