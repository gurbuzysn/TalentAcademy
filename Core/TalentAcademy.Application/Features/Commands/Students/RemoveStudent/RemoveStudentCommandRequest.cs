using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Commands.Students.RemoveStudent
{
    public class RemoveStudentCommandRequest : IRequest
    {
        public Guid Id { get; set; }

        public RemoveStudentCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
