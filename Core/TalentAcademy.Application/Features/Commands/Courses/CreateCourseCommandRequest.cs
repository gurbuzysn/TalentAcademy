using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Commands.Courses
{
    public class CreateCourseCommandRequest : IRequest<CreateCourseCommandResponse>
    {
        public string CourseName { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public IFormFile? Image { get; set; }

    }
}
