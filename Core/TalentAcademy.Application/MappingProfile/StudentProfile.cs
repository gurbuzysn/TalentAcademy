using AutoMapper;
using TalentAcademy.Application.Dtos.Student;
using TalentAcademy.Application.Features.Queries.Students.GetAllStudents;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.MappingProfile
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, GetAllStudentsQueryResponse>();
            CreateMap<Student, StudentDto>();
        }
    }
}
