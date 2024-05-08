using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Queries.Auth
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public CheckUserQueryHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<CheckUserQueryResponse> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.UserName);
            var userRole = _userManager.GetRolesAsync(user).Result.FirstOrDefault().ToString();

            var checkPassword = await _signInManager.PasswordSignInAsync(user, request.Password, true, true);

            var queryResponse = new CheckUserQueryResponse();   

            if (!checkPassword.Succeeded)
            {
                queryResponse.IsExist = false;
            }
            else 
            {
                queryResponse.Id = user.Id;
                queryResponse.UserName = user.UserName;
                queryResponse.IsExist = true;
                queryResponse.Role = userRole;
            }
            return queryResponse;
        }
    }
}
