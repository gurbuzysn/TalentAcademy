using AutoMapper;
using TalentAcademy.Application.Features.Queries.Student.GetByIdStudent;
using TalentAcademy.Application.Features.Queries.Students.GetByIdStudent;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.MappingProfile
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, CreateStudentCommandResponse>();
        }
    }
}
