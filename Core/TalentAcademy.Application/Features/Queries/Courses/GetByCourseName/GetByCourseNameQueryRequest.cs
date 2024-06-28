using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Queries.Courses.GetByCourseName
{
    public class GetByCourseNameQueryRequest : IRequest<GetByCourseNameQueryResponse>
    {
        public string CourseName { get; set; } = null!;
        public GetByCourseNameQueryRequest(string courseName)
        {
            CourseName = courseName;
        }
    }
}
