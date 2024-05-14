using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Queries.Users.GetUserById
{
    public class GetUserByIdQueryRequest : IRequest<GetUserByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetUserByIdQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
