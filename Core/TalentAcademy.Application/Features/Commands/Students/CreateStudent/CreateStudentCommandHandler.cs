using MediatR;
using Microsoft.AspNetCore.Identity;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Commands.Students.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommandRequest>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CreateStudentCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task Handle(CreateStudentCommandRequest request, CancellationToken cancellationToken)
        {
            // Tüm işi burada yapacağız
            // 1-) Öğrenciyi normal bir şekilde kaydedeceğiz. ancak bir farkla. fotografını veri tabanına göndermek yerine bir guid oluşturup onu veri tabanına kaydeceğiz. fotografı ise adı  aynı guidin sonuna uzantısını ekleyerek olşturduğumz isim ile wwwroot a kaydedeceğiz. 




            var userName = $"{request.FirstName.ToLower()}.{request.LastName.ToLower()}@talentacademy.com";
            var newStudent = new Student()
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
