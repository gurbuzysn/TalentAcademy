using MediatR;

namespace TalentAcademy.Application.Features.Queries.Student.GetAllStudent
{
    public class GetAllStudentsQueryRequest : IRequest<List<GetAllStudentsQueryResponse>>
    {
    }
}
