using AutoMapper;
using TalentAcademy.Application.Features.Commands.Courses.CreateCourse;
using TalentAcademy.Application.Features.Queries.Courses.GetAllCourses;
using TalentAcademy.Application.Features.Queries.Courses.GetCourseById;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.MappingProfile
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, GetAllCoursesQueryResponse>();
            CreateMap<Course, GetCourseByIdQueryResponse>();

            CreateMap<CreateCourseCommandRequest, Course>();
        }
    }
}
