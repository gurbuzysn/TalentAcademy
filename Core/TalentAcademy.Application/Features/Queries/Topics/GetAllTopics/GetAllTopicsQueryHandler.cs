using AutoMapper;
using MediatR;
using TalentAcademy.Application.Repositories;
using TalentAcademy.Domain.Entities;

namespace TalentAcademy.Application.Features.Queries.Topics.GetAllTopics
{
    public class GetAllTopicsQueryHandler : IRequestHandler<GetAllTopicsQueryRequest, List<GetAllTopicsQueryResponse>>
    {
        private readonly IReadRepository<Topic> _readRepository;
        private readonly IMapper _mapper;

        public GetAllTopicsQueryHandler(IReadRepository<Topic> readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllTopicsQueryResponse>> Handle(GetAllTopicsQueryRequest request, CancellationToken cancellationToken)
        {
            var allTopics = await _readRepository.GetAllAsync();
            return _mapper.Map<List<GetAllTopicsQueryResponse>>(allTopics);
        }
    }
}
