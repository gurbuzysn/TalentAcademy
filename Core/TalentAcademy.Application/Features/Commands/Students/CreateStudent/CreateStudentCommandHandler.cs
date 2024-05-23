using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using TalentAcademy.Application.Helpers;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Commands.Students.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommandRequest>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public CreateStudentCommandHandler(UserManager<IdentityUser> userManager, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _environment = environment;
        }
        public async Task Handle(CreateStudentCommandRequest request, CancellationToken cancellationToken)
        {
            string firstName = NameOperation.CharacterRegulatory(request.FirstName);
            string lastName = NameOperation.CharacterRegulatory(request.LastName);
            var userName = $"{firstName}.{lastName}@talentacademy.com";

            var newStudent = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = userName,
                NormalizedEmail = userName.ToUpper(),
                CreatedDate = DateTime.UtcNow,
            };

            if (request.Image != null)
            {
                var imageFileName = $"{Guid.NewGuid()}{Path.GetExtension(request.Image.FileName)}";
                var imagePath = Path.Combine(_environment.WebRootPath, "images", imageFileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await request.Image.CopyToAsync(stream);
                }
                newStudent.ImageUri = $"/images/{imageFileName}";
            }

            var createResult = await _userManager.CreateAsync(newStudent, "Student123*");
            if (createResult.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(newStudent, "Student");
            }

            throw new Exception("Öğrenci oluşturulurken bir hata oluştu");
        }
    }
}
