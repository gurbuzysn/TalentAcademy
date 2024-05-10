using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Queries.Students.GetAllStudents
{
    public class GetAllStudentsQueryRequest : IRequest<List<GetAllStudentsQueryResponse>>
    {
    }
}
