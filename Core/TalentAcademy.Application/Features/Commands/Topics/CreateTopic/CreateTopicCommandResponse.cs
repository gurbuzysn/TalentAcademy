using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Commands.Topics.CreateTopic
{
    public class CreateTopicCommandResponse
    {
        public string Name { get; set; } = null!;

        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}