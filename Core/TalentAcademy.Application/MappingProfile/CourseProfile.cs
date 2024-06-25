﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Features.Commands.Courses;
using TalentAcademy.Application.Features.Queries.Courses.GetAllCourses;
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
        }
    }
}
