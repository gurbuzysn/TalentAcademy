using MediatR;
using Microsoft.AspNetCore.Http;
using TalentAcademy.Domain.Enums;

namespace TalentAcademy.Application.Features.Commands.Students.CreateStudent
{
    public class CreateStudentCommandRequest : IRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public IFormFile? Image { get; set; }
    }
}
