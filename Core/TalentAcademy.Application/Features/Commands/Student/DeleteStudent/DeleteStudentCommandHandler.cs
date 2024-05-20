using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Commands.Student.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommandRequest>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteStudentCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task Handle(DeleteStudentCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedStudent = await _userManager.FindByIdAsync(request.Id.ToString());

            var result = await _userManager.DeleteAsync(deletedStudent!);
        }
    }
}
