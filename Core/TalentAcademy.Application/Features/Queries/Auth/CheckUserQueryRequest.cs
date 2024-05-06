using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Queries.Auth
{
    public class CheckUserQueryRequest : IRequest<CheckUserQueryResponse>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
