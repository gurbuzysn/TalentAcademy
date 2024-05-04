using MediatR;

namespace TalentAcademy.Application.Features.Queries.Student.GetStudentById
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
