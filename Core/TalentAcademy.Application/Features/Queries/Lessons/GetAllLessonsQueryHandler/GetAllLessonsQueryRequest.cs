using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Queries.Lessons.GetAllLessonsQueryHandler
{
    public class GetAllLessonsQueryRequest : IRequest<List<GetAllLessonsQueryResponse>>
    {
    }
}
