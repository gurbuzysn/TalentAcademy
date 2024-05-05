using MediatR;

namespace TalentAcademy.Application.Features.Commands.Topics.UpdateTopic
{
    public class UpdateTopicCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
