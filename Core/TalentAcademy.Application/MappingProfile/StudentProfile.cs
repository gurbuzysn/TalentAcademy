using AutoMapper;
using TalentAcademy.Application.Features.Commands.Students.CreateStudent;
using TalentAcademy.Application.Features.Queries.Student.GetAllStudent;
using TalentAcademy.Application.Features.Queries.Student.GetByIdStudent;
using TalentAcademy.Application.Features.Queries.Student.GetStudentById;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.MappingProfile
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, GetAllStudentsQueryResponse>();
            CreateMap<Student, GetStudentByIdQueryResponse>();
            
            CreateMap<Student, CreateStudentCommandResponse>();
            CreateMap<CreateStudentCommandRequest, Student>();
        }
    }
}
