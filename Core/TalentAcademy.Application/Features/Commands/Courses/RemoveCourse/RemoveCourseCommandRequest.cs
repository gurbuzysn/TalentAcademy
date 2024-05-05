using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Commands.Courses.RemoveCourse
{
    public class RemoveCourseCommandRequest : IRequest
    {
        public Guid Id { get; set; }
        public RemoveCourseCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
