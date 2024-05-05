using MediatR;

namespace TalentAcademy.Application.Features.Queries.Lessons.GetLessonQueryHandler
{
    public class GetLessonByIdQueryRequest : IRequest<GetLessonByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetLessonByIdQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
