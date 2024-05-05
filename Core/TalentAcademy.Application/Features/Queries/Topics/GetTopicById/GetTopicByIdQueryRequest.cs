using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Queries.Topics.GetTopicById
{
    public class GetTopicByIdQueryRequest : IRequest<GetTopicByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetTopicByIdQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
