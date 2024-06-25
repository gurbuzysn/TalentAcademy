using AutoMapper;
using TalentAcademy.Application.Dtos.Topic;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.MappingProfile
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<Topic, TopicDto>();
        }
    }
}