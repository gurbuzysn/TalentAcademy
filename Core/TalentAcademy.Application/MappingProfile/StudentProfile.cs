using AutoMapper;
using TalentAcademy.Application.Features.Queries.Students.GetAllStudents;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.MappingProfile
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<AppUser, GetAllStudentsQueryResponse>();
        }
    }
}
