using AutoMapper;
using TalentAcademy.Application.Features;
using TalentAcademy.Application.Features.Queries.Auth;

namespace TalentAcademy.WebAPI.MappingProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CheckUserQueryResponse, GeneralResponse>();
        }
    }
}
