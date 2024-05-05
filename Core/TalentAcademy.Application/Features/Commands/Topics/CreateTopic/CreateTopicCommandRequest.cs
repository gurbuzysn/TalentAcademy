using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Commands.Topics.CreateTopic
{
    public class CreateTopicCommandRequest : IRequest<CreateTopicCommandResponse>
    {
        public string Name { get; set; } = null!;

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}
