using MediatR;

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
