using MediatR;

namespace TalentAcademy.Application.Features.Queries.Students.GetAllStudents
{
    public class GetAllStudentsQueryRequest : IRequest<List<GetAllStudentsQueryResponse>>
    {
    }
}
