using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Commands.Courses.CreateCourse
{
    public class CreateCourseCommandRequest : IRequest<CreateCourseCommandResponse>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
    }
}
