using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Commands.Student.DeleteStudent
{
    public class DeleteStudentCommandRequest : IRequest
    {
        public Guid Id { get; set; }

        public DeleteStudentCommandRequest(Guid id)
        {
            Id = id;
        }
    }
}
