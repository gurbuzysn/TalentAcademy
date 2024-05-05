using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
