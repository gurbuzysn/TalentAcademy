using MediatR;

namespace TalentAcademy.Application.Features.Queries.Topics.GetTopicById
{
    public class GetTopicByIdQueryRequest : IRequest<GetTopicByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetTopicByIdQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
