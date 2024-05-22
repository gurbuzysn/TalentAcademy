﻿using MediatR;

namespace TalentAcademy.Application.Features.Commands.Students.DeleteStudent
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