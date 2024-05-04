using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Commands.Students.RemoveStudent
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommandRequest>
    {
        private readonly IReadRepository<Student> _readRepository;
        private readonly IWriteRepository<Student> _writeRepository;
        private readonly IMapper _mapper;

        public RemoveStudentCommandHandler(IReadRepository<Student> readRepository, IWriteRepository<Student> writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
        public async Task Handle(RemoveStudentCommandRequest request, CancellationToken cancellationToken)
        {
            var student = await _readRepository.GetByIdAsync(request.Id);
            if (student != null) 
            { 
                await _writeRepository.RemoveAsync(student);
            }
        }
    }
}
