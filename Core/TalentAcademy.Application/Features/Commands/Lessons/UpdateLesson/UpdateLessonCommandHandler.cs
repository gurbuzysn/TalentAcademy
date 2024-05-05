using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Commands.Lessons.UpdateLesson
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommandRequest>
    {
        private readonly IReadRepository<Lesson> _readRepository;
        private readonly IWriteRepository<Lesson> _writeRepository;
        private readonly IMapper _mapper;

        public UpdateLessonCommandHandler(IReadRepository<Lesson> readRepository, IWriteRepository<Lesson> writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateLessonCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedLesson = await _readRepository.GetByIdAsync(request.Id);

            if(updatedLesson != null)
            {
                updatedLesson.UpdatedDate = DateTime.UtcNow;
                updatedLesson.Name = request.Name;

               await _writeRepository.UpdateAsync(updatedLesson);
            }
        }
    }
}
