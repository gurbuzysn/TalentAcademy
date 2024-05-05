using MediatR;

namespace TalentAcademy.Application.Features.Queries.Courses.GetCourseById
{
    public class GetCourseByIdQueryRequest : IRequest<GetCourseByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetCourseByIdQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
