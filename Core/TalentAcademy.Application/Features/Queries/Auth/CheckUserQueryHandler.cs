using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Exceptions;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Queries.Auth
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserQueryResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CheckUserQueryHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }


        public async Task<CheckUserQueryResponse> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            //var user = await _userManager.FindByEmailAsync(request.UserName);

            //if (user == null)
            //    throw new UserNotFoundException();

            //var userRole = _userManager.GetRolesAsync(user).Result.FirstOrDefault().ToString();

            //var checkPassword = await _signInManager.PasswordSignInAsync(user, request.Password, true, true);

            //var queryResponse = new CheckUserQueryResponse();

            //if (!checkPassword.Succeeded)
            //{
            //    queryResponse.IsExist = false;
            //}
            //else
            //{
            //    queryResponse.Id = user.Id;
            //    queryResponse.UserName = user.UserName;
            //    queryResponse.FullName = user.FullName;
            //    queryResponse.IsExist = true;
            //    queryResponse.Role = userRole;
            //}
            //return queryResponse;

            throw new NotImplementedException();

        }
    }
}
