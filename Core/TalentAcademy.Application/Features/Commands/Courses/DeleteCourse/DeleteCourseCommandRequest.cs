using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Commands.Courses.DeleteCourse
{
    public class DeleteCourseCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public DeleteCourseCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
