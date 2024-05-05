using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Commands.Topics.UpdateTopic
{
    public class UpdateTopicCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
