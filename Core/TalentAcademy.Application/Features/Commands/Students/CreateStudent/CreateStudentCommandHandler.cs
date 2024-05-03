using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Features.Queries.Student.GetByIdStudent;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Commands.Students.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommandRequest, CreateStudentCommandResponse>
    {
        private readonly IWriteRepository<Student> _writeRepository;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IWriteRepository<Student> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
    
    }
}
