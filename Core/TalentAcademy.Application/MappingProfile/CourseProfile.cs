﻿using AutoMapper;
using TalentAcademy.Application.Features.Commands.Courses;
using TalentAcademy.Application.Features.Queries.Courses.GetAllCourses;
using TalentAcademy.Application.Features.Queries.Courses.GetByCourseName;
using TalentAcademy.Application.Features.Queries.Courses.GetCourseById;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.MappingProfile
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CreateCourseCommandRequest, Course>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CourseName));
            CreateMap<Course, GetAllCoursesQueryResponse>();
            CreateMap<Course, GetByCourseNameQueryResponse>();
            CreateMap<Course, GetCourseByIdQueryResponse>();
        }
    }
}
