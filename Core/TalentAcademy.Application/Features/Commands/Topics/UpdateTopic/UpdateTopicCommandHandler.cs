using AutoMapper;
using MediatR;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Commands.Topics.UpdateTopic
{
    public class UpdateTopicCommandHandler : IRequestHandler<UpdateTopicCommandRequest>
    {
        private readonly IWriteRepository<Topic> _writeRepository;
        private readonly IReadRepository<Topic> _readRepository;
        private readonly IMapper _mapper;

        public UpdateTopicCommandHandler(IWriteRepository<Topic> writeRepository, IReadRepository<Topic> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateTopicCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedTopic = await _readRepository.GetByIdAsync(request.Id);
            if (updatedTopic != null)
            {
                updatedTopic.Name = request.Name;
                updatedTopic.UpdatedDate = DateTime.UtcNow;

                await _writeRepository.UpdateAsync(updatedTopic);
            }
        }
    }
}
