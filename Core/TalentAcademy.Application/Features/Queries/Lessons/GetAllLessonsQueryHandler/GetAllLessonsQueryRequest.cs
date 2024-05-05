using MediatR;

namespace TalentAcademy.Application.Features.Queries.Lessons.GetAllLessonsQueryHandler
{
    public class GetAllLessonsQueryRequest : IRequest<List<GetAllLessonsQueryResponse>>
    {
    }
}
