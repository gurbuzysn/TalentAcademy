using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Features.Commands.Lessons.CreateLesson;
using TalentAcademy.Application.Features.Queries.Lessons.GetAllLessonsQueryHandler;
using TalentAcademy.Application.Features.Queries.Lessons.GetLessonQueryHandler;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.MappingProfile
{
    public class LessonProfile :Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson, GetAllLessonsQueryResponse>();
            CreateMap<Lesson, GetLessonByIdQueryResponse>();

            CreateMap<CreateLessonCommandRequest, Lesson>();
            CreateMap<Lesson, CreateLessonCommandResponse>();
        }
    }
}
