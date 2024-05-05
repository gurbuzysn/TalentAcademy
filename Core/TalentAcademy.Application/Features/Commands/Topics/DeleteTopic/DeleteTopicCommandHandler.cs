using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;
using TalentAcademy.Domain.Entities.Identitiy;

namespace TalentAcademy.Application.Features.Commands.Topics.DeleteTopic
{
    public class DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommandRequest>
    {
        private readonly IReadRepository<Topic> _readRepository;
        private readonly IWriteRepository<Topic> _writeRepository;
        private readonly IMapper _mapper;

        public DeleteTopicCommandHandler(IReadRepository<Topic> readRepository, IWriteRepository<Topic> writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
        public async Task Handle(DeleteTopicCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedTopic = await _readRepository.GetByIdAsync(request.Id);

            if(deletedTopic != null)
                await _writeRepository.RemoveAsync(deletedTopic);
        }
    }
}
