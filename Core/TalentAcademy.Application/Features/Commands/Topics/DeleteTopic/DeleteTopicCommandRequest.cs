using MediatR;

namespace TalentAcademy.Application.Features.Commands.Topics.DeleteTopic
{
    public class DeleteTopicCommandRequest : IRequest
    {
        public Guid Id { get; set; }

        public DeleteTopicCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
