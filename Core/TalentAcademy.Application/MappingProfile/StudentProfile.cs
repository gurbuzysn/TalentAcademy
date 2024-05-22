using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TalentAcademy.Application.Features.Queries.Students.GetAllStudents;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.MappingProfile
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            //CreateMap<IdentityUser, GetAllStudentsQueryResponse>();
            //CreateMap<AppUser, GetAllStudentsQueryResponse>();
            CreateMap<Student, GetAllStudentsQueryResponse>();
        }
    }
}
