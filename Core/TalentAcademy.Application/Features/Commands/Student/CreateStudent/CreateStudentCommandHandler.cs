using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Constants;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Commands.Student.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommandRequest>
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateStudentCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task Handle(CreateStudentCommandRequest request, CancellationToken cancellationToken)
        {
            var userName = $"{request.FirstName.ToLower()}.{request.LastName.ToLower()}@talentacademy.com";
            var newStudent = new AppUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = userName,
                NormalizedEmail = userName.ToUpper(),
                CreatedDate = DateTime.UtcNow,
            };

            var createResult = await _userManager.CreateAsync(newStudent, "Student123*");
            var roleResult = await _userManager.AddToRoleAsync(newStudent, "Student");
        }
    }
}
