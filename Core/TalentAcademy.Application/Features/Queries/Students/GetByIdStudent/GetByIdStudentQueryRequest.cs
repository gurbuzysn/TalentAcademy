using MediatR;

namespace TalentAcademy.Application.Features.Queries.Student.GetByIdStudent
{
    public class GetStudentByIdQueryRequest : IRequest<GetStudentByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetStudentByIdQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
