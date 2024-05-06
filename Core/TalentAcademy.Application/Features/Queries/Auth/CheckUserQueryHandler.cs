using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Queries.Auth
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserQueryResponse>
    {
        private readonly IReadRepository<AppUser> _userReadRepository;
        private readonly IReadRepository<AppRole> _roleReadRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public CheckUserQueryHandler(IReadRepository<AppUser> userReadRepository, IReadRepository<AppRole> roleReadRepository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userReadRepository = userReadRepository;
            _roleReadRepository = roleReadRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<CheckUserQueryResponse> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserQueryResponse();

            var user = await _userManager.FindByEmailAsync(request.UserName);

            if(user == null)
            {
                dto.IsExist = false;
            }

            var checkPassword = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if (checkPassword.Succeeded)
            {
                dto.IsExist = true;
                dto.UserName = user.UserName;
                //dto.Role = user.Role;
                dto.Id = user.Id;
            }

            return dto;
        }
    }
}
