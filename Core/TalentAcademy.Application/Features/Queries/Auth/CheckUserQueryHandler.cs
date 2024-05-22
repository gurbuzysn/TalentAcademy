using MediatR;
using Microsoft.AspNetCore.Identity;

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
            var user = await _userManager.FindByEmailAsync(request.UserName);
            var queryResponse = new CheckUserQueryResponse();

            if (user == null)
            {
                queryResponse.IsExist = false;
                queryResponse.ErrorMessage = "Kullanıcı adı veya parola hatalı. Lütfen tekrar deneyiniz";
            }

            var userRole = _userManager.GetRolesAsync(user!).Result.FirstOrDefault();
            if (userRole == null)
                throw new Exception("Role Bulunmadı");

            var checkPassword = await _signInManager.PasswordSignInAsync(user!, request.Password, true, true);

            if (!checkPassword.Succeeded)
            {
                queryResponse.IsExist = false;
                queryResponse.ErrorMessage = "Kullanıcı adı veya parola hatalı. Lütfen tekrar deneyiniz";
            }
            else
            {
                queryResponse.Id = Guid.Parse(user!.Id);
                queryResponse.UserName = user.UserName!;
                queryResponse.FullName = "Abc";
                queryResponse.IsExist = true;
                queryResponse.Role = userRole!;
            }
            return queryResponse;


        }
    }
}
