using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Domain.Enums;

namespace TalentAcademy.Application.Features.Commands.Student.CreateStudent
{
    public class CreateStudentCommandRequest : IRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {LastName}";
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ImageUri { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
