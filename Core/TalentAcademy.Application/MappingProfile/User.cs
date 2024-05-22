using AutoMapper;
using TalentAcademy.Application.Features.Queries.Users.GetUserById;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.MappingProfile
{
    public class User : Profile
    {
        public User()
        {
            CreateMap<AppUser, GetUserByIdQueryResponse>();
        }
    }
}
