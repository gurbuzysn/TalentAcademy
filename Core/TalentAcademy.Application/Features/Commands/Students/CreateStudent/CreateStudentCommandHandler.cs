using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using TalentAcademy.Application.Dtos;
using TalentAcademy.Application.Helpers;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Commands.Students.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommandRequest, GeneralResponse>
     {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _environment;
        private readonly GeneralResponse _response;

        public CreateStudentCommandHandler(UserManager<IdentityUser> userManager, IWebHostEnvironment environment, GeneralResponse response)
        {
            _userManager = userManager;
            _environment = environment;
            _response = response;
        }
        public async Task<GeneralResponse> Handle(CreateStudentCommandRequest request, CancellationToken cancellationToken)
        {
            string firstName = NameOperation.CharacterRegulatory(request.FirstName);
            string lastName = NameOperation.CharacterRegulatory(request.LastName);
            var userName = $"{firstName.ToLower()}.{lastName.ToLower()}@talentacademy.com";

            var newStudent = new Student()
            {
                FirstName = firstName,
                LastName = lastName.ToUpper(),
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
                _response.Status = System.Net.HttpStatusCode.Created;
                _response.IsSuccess = true;
                _response.Message = $"{firstName} {lastName} isimli kullanıcı başarıyla eklendi";
                return _response;
            }

            _response.IsSuccess = false;
            _response.Message = "Kullanıcıyı eklerken bir hata meydana geldi";
            return _response;
        }

       
    }
}
