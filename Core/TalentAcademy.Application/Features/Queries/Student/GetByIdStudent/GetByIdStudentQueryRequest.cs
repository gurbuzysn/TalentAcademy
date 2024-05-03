﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAcademy.Application.Features.Queries.Student.GetByIdStudent
{
    public class GetStudentByIdQueryRequest : IRequest<GetStudentByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetStudentByIdQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
