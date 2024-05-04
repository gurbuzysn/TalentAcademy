using AutoMapper;
using MediatR;
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

        public async Task<CreateStudentCommandResponse> Handle(CreateStudentCommandRequest request, CancellationToken cancellationToken)
        {
            var createStudent = _mapper.Map<Student>(request);
            var result = await _writeRepository.CreateAsync(createStudent);
            return _mapper.Map<CreateStudentCommandResponse>(result);
        }
    }
}
