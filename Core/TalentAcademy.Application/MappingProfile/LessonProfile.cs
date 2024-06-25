using AutoMapper;
using TalentAcademy.Application.Dtos.Lesson;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.MappingProfile
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson, LessonDto>();
        }
    }
}







