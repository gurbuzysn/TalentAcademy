﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Dtos.Student;

namespace TalentAcademy.Application.Features.Queries.Student.GetAllStudent
{
    public class GetAllStudentQueryRequest : IRequest<StudentDto>
    {
    }
}
