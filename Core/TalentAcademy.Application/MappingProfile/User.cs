using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
