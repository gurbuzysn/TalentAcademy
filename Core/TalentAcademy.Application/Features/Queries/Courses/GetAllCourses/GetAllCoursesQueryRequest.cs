using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Features.Queries.Students.GetAllStudents;

namespace TalentAcademy.Application.Features.Queries.Courses.GetAllCourses
{
    public class GetAllCoursesQueryRequest : IRequest<List<GetAllCoursesQueryResponse>>
    {
    }
}
