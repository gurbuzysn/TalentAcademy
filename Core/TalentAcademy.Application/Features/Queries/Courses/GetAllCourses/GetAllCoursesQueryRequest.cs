using MediatR;

namespace TalentAcademy.Application.Features.Queries.Courses.GetAllCourses
{
    public class GetAllCoursesQueryRequest : IRequest<List<GetAllCoursesQueryResponse>>
    {
    }
}
