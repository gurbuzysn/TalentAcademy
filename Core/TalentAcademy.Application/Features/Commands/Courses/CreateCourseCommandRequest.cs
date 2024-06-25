using MediatR;
using Microsoft.AspNetCore.Http;

namespace TalentAcademy.Application.Features.Commands.Courses
{
    public class CreateCourseCommandRequest : IRequest<CreateCourseCommandResponse>
    {
        public string CourseName { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public IFormFile? Image { get; set; }

    }
}
