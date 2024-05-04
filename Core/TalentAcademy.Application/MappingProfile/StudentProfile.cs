using AutoMapper;
using TalentAcademy.Application.Features.Commands.Students.CreateStudent;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.MappingProfile
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, CreateStudentCommandResponse>();
            CreateMap<CreateStudentCommandRequest, Student>();
        }
    }
}
