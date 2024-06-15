﻿using MediatR;
using Microsoft.AspNetCore.Identity;

namespace TalentAcademy.Application.Features.Queries.Auth
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, GeneralResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly GeneralResponse _response;

        public CheckUserQueryHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, GeneralResponse response)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _response = response;
        }

        public async Task<GeneralResponse> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.UserName);
            var queryResponse = new CheckUserQueryResponse();

            if (user == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Kullanıcı adı veya parola hatalı. Lütfen tekrar deneyiniz";

                return _response;
            }

            var userRole = _userManager.GetRolesAsync(user!).Result.FirstOrDefault();
            if (userRole == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Kullanıcıya ait role bilgisi bulunamadı";

            }

            var checkPassword = await _signInManager.PasswordSignInAsync(user!, request.Password, true, true);

            if (!checkPassword.Succeeded)
            {
                _response.IsSuccess = false;
                _response.Message = "Kullanıcı adı veya parola hatalı. Lütfen tekrar deneyiniz";
                _response.Status = System.Net.HttpStatusCode.BadRequest;
            }
            else
            {
                queryResponse.Id = Guid.Parse(user!.Id);
                queryResponse.UserName = user.UserName!;
                queryResponse.FullName = "";
                queryResponse.Role = userRole!;

                _response.IsSuccess = true;
                _response.Message = "Giriş Başarılı";
                _response.Status = System.Net.HttpStatusCode.OK;
                _response.Result = queryResponse;

            }
            return _response;
        }
    }
}
