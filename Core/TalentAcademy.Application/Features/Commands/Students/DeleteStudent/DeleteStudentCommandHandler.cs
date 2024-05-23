using MediatR;
using Microsoft.AspNetCore.Identity;

namespace TalentAcademy.Application.Features.Commands.Students.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommandRequest, GeneralResponse>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly GeneralResponse _response;

        public DeleteStudentCommandHandler(UserManager<IdentityUser> userManager, GeneralResponse response)
        {
            _userManager = userManager;
            _response = response;
        }
        public async Task<GeneralResponse> Handle(DeleteStudentCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedStudent = await _userManager.FindByIdAsync(request.Id.ToString());
            var result = await _userManager.DeleteAsync(deletedStudent!);


            if (result.Succeeded)
            {
                _response.Message = "Kullanıcı başarıyla silindi";
                return _response;
            }

            _response.Message = "Silme işlemi başarısız";
            return _response;
        }
    }
}
