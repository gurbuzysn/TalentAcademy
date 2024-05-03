using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Queries.Student.GetAllStudent
{
    internal class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQueryRequest, GetAllStudentsQueryResponse>
    {
        public Task<GetAllStudentsQueryResponse> Handle(GetAllStudentsQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
