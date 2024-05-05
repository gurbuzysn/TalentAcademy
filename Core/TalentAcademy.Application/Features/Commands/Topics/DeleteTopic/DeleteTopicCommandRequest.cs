using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Commands.Topics.DeleteTopic
{
    public class DeleteTopicCommandRequest : IRequest
    {
        public Guid Id { get; set; }

        public DeleteTopicCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
