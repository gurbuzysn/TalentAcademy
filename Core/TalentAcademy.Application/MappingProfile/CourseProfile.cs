using AutoMapper;
using TalentAcademy.Application.Features.Queries.Courses.GetAllCourses;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.MappingProfile
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, GetAllCoursesQueryResponse>();
        }
    }
}
