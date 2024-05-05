using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Commands.Topics.CreateTopic
{
    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommandRequest, CreateTopicCommandResponse>
    {
        private readonly IWriteRepository<Topic> _writeRepository;
        private readonly IMapper _mapper;

        public CreateTopicCommandHandler(IWriteRepository<Topic> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }
        public async Task<CreateTopicCommandResponse> Handle(CreateTopicCommandRequest request, CancellationToken cancellationToken)
        {
            var createdTopic = _mapper.Map<Topic>(request);
            await _writeRepository.CreateAsync(createdTopic);
            return _mapper.Map<CreateTopicCommandResponse>(createdTopic);
        }
    }
}
