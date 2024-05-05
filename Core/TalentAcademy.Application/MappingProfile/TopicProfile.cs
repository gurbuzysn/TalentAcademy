using AutoMapper;
using TalentAcademy.Application.Features.Commands.Topics.CreateTopic;
using TalentAcademy.Application.Features.Queries.Topics.GetAllTopics;
using TalentAcademy.Application.Features.Queries.Topics.GetTopicById;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.MappingProfile
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<Topic, GetAllTopicsQueryResponse>();
            CreateMap<Topic, GetTopicByIdQueryResponse>();

            CreateMap<CreateTopicCommandRequest, Topic>();
            CreateMap<Topic, CreateTopicCommandResponse>();
        }
    }
}
