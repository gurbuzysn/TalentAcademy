using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Commands.Lessons.UpdateLesson
{
    public class UpdateLessonCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        
    }
}
