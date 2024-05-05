using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Commands.Lessons.CreateLesson
{
    public class CreateLessonCommandRequest : IRequest<CreateLessonCommandResponse>
    {
        public string Name { get; set; } = null!;

    }
}
