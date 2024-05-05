using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Queries.Topics.GetTopicById
{
    public class GetTopicByIdQueryHandler : IRequestHandler<GetTopicByIdQueryRequest, GetTopicByIdQueryResponse>
    {
        private readonly IReadRepository<Topic> _readRepository;
        private readonly IMapper _mapper;

        public GetTopicByIdQueryHandler(IReadRepository<Topic> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<GetTopicByIdQueryResponse> Handle(GetTopicByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var topic = await _readRepository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<GetTopicByIdQueryResponse>(topic);
        }
    }
}
