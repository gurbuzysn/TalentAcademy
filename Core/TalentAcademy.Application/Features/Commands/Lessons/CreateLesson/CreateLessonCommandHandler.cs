using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Commands.Lessons.CreateLesson
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommandRequest, CreateLessonCommandResponse>
    {
        private readonly IWriteRepository<Lesson> _writeRepository;
        private readonly IMapper _mapper;

        public CreateLessonCommandHandler(IWriteRepository<Lesson> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
        public async Task<CreateLessonCommandResponse> Handle(CreateLessonCommandRequest request, CancellationToken cancellationToken)
        {
            var createdLesson = _mapper.Map<Lesson>(request);
            await _writeRepository.CreateAsync(createdLesson);

            return _mapper.Map<CreateLessonCommandResponse>(createdLesson);
        }
    }
}
