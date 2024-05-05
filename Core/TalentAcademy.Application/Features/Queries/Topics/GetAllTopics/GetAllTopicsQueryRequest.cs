using MediatR;

namespace TalentAcademy.Application.Features.Queries.Topics.GetAllTopics
{
    public class GetAllTopicsQueryRequest : IRequest<List<GetAllTopicsQueryResponse>>
    {
    }
}
