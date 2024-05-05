using AutoMapper;
using MediatR;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Commands.Lessons.DeleteLesson
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommandRequest>
    {
        private readonly IReadRepository<Lesson> _readRepository;
        private readonly IWriteRepository<Lesson> _writeRepository;
        private readonly IMapper _mapper;

        public DeleteLessonCommandHandler(IReadRepository<Lesson> readRepository, IWriteRepository<Lesson> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }
        public async Task Handle(DeleteLessonCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedLesson = await _readRepository.GetByIdAsync(request.Id);
            if (deletedLesson != null)
            {
                await _writeRepository.RemoveAsync(deletedLesson);
            }
        }
    }
}
