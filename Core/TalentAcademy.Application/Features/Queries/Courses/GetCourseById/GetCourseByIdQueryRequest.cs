using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
